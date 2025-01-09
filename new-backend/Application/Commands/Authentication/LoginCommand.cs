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
    public record LoginCommand(string Email, string Password) : IRequest<LoginResponseDto>;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly IValidator<LoginCommand> _validator;

        public LoginCommandHandler(
            IUserRepository userRepository,
            ITokenService tokenService,
            IMapper mapper,
            ILogger<LoginCommandHandler> logger,
            IValidator<LoginCommand> validator)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !user.PasswordHash.Verify(request.Password))
            {
                _logger.LogWarning("Login failed for {Email}", request.Email);
                throw new InvalidCredentialsException("Invalid email or password.");
            }

            var tokens = _tokenService.GenerateToken(user);
            await _tokenService.PersistRefreshTokenAsync(tokens.RefreshToken, user.Id);

            _logger.LogInformation("User {Email} authenticated successfully.", request.Email);

            return new LoginResponseDto
            {
                Token = tokens.JwtToken,
                RefreshToken = tokens.RefreshToken.Token,
                ExpiresAt = tokens.RefreshToken.ExpiresAt,
                User = _mapper.Map<UserDto>(user)
            };
        }
    }
}
