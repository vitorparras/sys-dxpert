using Application.DTOs;
using Application.Mappers;
using Core.Interfaces;

namespace Application.UseCases.Login
{
    public class RefreshTokenUseCase
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public RefreshTokenUseCase(IRefreshTokenRepository refreshTokenRepository, IAuthService authService, IUserRepository userRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> ExecuteAsync(string refreshToken)
        {
            var storedRefreshToken = await _refreshTokenRepository.GetByTokenAsync(refreshToken);
            if (storedRefreshToken == null || storedRefreshToken.IsExpired())
            {
                throw new UnauthorizedAccessException("Invalid or expired refresh token");
            }

            var user = await _userRepository.GetByIdAsync(storedRefreshToken.UserId);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            var newJwtToken = _authService.GenerateJwtToken(user);
            var newRefreshToken = _authService.GenerateRefreshToken(user);

            await _refreshTokenRepository.DeleteAsync(storedRefreshToken);
            await _refreshTokenRepository.CreateAsync(newRefreshToken);

            return new LoginResponseDto
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken.Token,
                ExpiresAt = newRefreshToken.ExpiresAt,
                User = UserMapper.ToDto(user)
            };
        }
    }
}

