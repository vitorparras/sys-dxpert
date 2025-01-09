using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Exceptions;
using FluentValidation;
using Infrastructure.Repositorys.interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Authentication
{
    public record RefreshTokenCommand(string RefreshToken) : IRequest<LoginResponseDto>;

    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ILogger<RefreshTokenCommandHandler> _logger;
        private readonly IValidator<RefreshTokenCommand> _validator;

        public RefreshTokenCommandHandler(
            IUserRepository userRepository,
            ITokenService tokenService,
            IMapper mapper,
            ILogger<RefreshTokenCommandHandler> logger,
            IValidator<RefreshTokenCommand> validator)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        public async Task<LoginResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var user = await _userRepository.GetByRefreshTokenAsync(request.RefreshToken);
            if (user == null)
            {
                _logger.LogWarning("Invalid refresh token attempt.");
                throw new InvalidCredentialsException("Invalid or expired refresh token.");
            }

            var storedToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == request.RefreshToken);

            if (storedToken == null || storedToken.IsExpired)
            {
                _logger.LogWarning("Expired or invalid refresh token for user {UserId}", user.Id);
                throw new InvalidCredentialsException("Invalid or expired refresh token.");
            }

            var newTokens = _tokenService.GenerateToken(user);

            user.RefreshTokens.Remove(storedToken);
            await _tokenService.PersistRefreshTokenAsync(newTokens.RefreshToken, user.Id);

            _logger.LogInformation("Refresh token renewed successfully for user {UserId}", user.Id);

            return new LoginResponseDto
            {
                Token = newTokens.JwtToken,
                RefreshToken = newTokens.RefreshToken.Token,
                ExpiresAt = newTokens.RefreshToken.ExpiresAt,
                User = _mapper.Map<UserDto>(user)
            };
        }
    }
}
