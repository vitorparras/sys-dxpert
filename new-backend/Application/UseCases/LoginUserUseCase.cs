using Application.DTOs;
using Application.Mappers;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ILogger<LoginUserUseCase> _logger;

        public LoginUserUseCase(
            IUserRepository userRepository,
            IAuthService authService,
            IRefreshTokenRepository refreshTokenRepository,
            ILogger<LoginUserUseCase> logger)
        {
            _userRepository = userRepository;
            _authService = authService;
            _refreshTokenRepository = refreshTokenRepository;
            _logger = logger;
        }

        public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto request)
        {
            _logger.LogInformation("Attempting login for user: {Email}", request.Email);

            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !_authService.ValidatePassword(request.Password, user.PasswordHash.Value))
            {
                _logger.LogWarning("Login failed for user: {Email}", request.Email);
                throw new UnauthorizedAccessException("Invalid email or password");
            }

            var jwtToken = _authService.GenerateJwtToken(user);
            var refreshToken = _authService.GenerateRefreshToken(user);
            await _refreshTokenRepository.CreateAsync(refreshToken);

            _logger.LogInformation("Login successful for user: {Email}", request.Email);

            return new LoginResponseDto
            {
                Token = jwtToken,
                RefreshToken = refreshToken.Token,
                ExpiresAt = refreshToken.ExpiresAt,
                User = UserMapper.ToDto(user)
            };
        }
    }
}

