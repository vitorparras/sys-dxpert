using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ILogger<RefreshTokenService> _logger;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, ILogger<RefreshTokenService> logger)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _logger = logger;
        }

        public async Task<RefreshToken> GenerateRefreshTokenAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var refreshToken = new RefreshToken(user, DateTime.UtcNow.AddDays(7));
            await _refreshTokenRepository.CreateAsync(refreshToken);

            _logger.LogInformation("Refresh token generated for user ID: {UserId}", user.Id);
            return refreshToken;
        }

        public async Task ValidateRefreshTokenAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.LogWarning("Refresh token validation failed: Token was empty.");
                throw new InvalidTokenException("Refresh token is required.");
            }

            var storedToken = await _refreshTokenRepository.GetByTokenAsync(token);
            if (storedToken == null || storedToken.IsExpired())
            {
                _logger.LogWarning("Invalid or expired refresh token provided.");
                throw new InvalidTokenException("Invalid or expired refresh token.");
            }

            _logger.LogInformation("Refresh token validated successfully for User ID: {UserId}", storedToken.UserId);
        }

        public async Task RevokeRefreshTokenAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.LogWarning("Attempt to revoke an empty refresh token.");
                throw new ArgumentException("Token cannot be empty.");
            }

            var storedToken = await _refreshTokenRepository.GetByTokenAsync(token);
            if (storedToken == null)
            {
                _logger.LogWarning("Attempt to revoke a non-existing refresh token.");
                throw new InvalidTokenException("Token not found.");
            }

            await _refreshTokenRepository.DeleteAsync(storedToken);
            _logger.LogInformation("Refresh token revoked successfully for User ID: {UserId}", storedToken.UserId);
        }
    }
}
