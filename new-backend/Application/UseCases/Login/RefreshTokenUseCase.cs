using Application.DTOs;
using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Login
{
    public interface IRefreshTokenUseCase
    {
        Task<LoginResponseDto> ExecuteAsync(string refreshToken);
    }

    public class RefreshTokenUseCase : IRefreshTokenUseCase
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RefreshTokenUseCase> _logger;
        private readonly IMapper _mapper;

        public RefreshTokenUseCase(
            IRefreshTokenRepository refreshTokenRepository,
            IAuthService authService,
            IUserRepository userRepository,
            ILogger<RefreshTokenUseCase> logger,
            IMapper mapper)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _authService = authService;
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> ExecuteAsync(string refreshToken)
        {
            _logger.LogInformation("Starting refresh token process");

            var storedRefreshToken = await _refreshTokenRepository.GetByTokenAsync(refreshToken);
            if (storedRefreshToken == null || storedRefreshToken.IsExpired())
            {
                _logger.LogWarning("Invalid or expired refresh token provided");
                throw new InvalidTokenException("Invalid or expired refresh token");
            }

            var user = await _userRepository.GetByIdAsync(storedRefreshToken.UserId);
            if (user == null)
            {
                _logger.LogError("User not found for refresh token: {Token}", refreshToken);
                throw new UserNotFoundException("User not found");
            }

            _logger.LogInformation("Valid refresh token and user found for UserId: {UserId}", user.Id);

            var newJwtToken = _authService.GenerateJwtToken(user);
            var newRefreshToken = _authService.GenerateRefreshToken(user);


            await _refreshTokenRepository.DeleteAsync(storedRefreshToken);
            await _refreshTokenRepository.CreateAsync(newRefreshToken);

            _logger.LogInformation("Successfully refreshed tokens for UserId: {UserId}", user.Id);

            return new LoginResponseDto
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken.Token,
                ExpiresAt = newRefreshToken.ExpiresAt,
                User = _mapper.Map<UserDto>(user)
            };
        }
    }
}
