using Application.DTOs;
using Application.Mappers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Security.Authentication;

namespace Application.UseCases.Login
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<LoginUserUseCase> _logger;

        public LoginUserUseCase(
            IUserRepository userRepository,
            IAuthService authService,
            ITokenService tokenService,
            ILogger<LoginUserUseCase> logger)
        {
            _userRepository = userRepository;
            _authService = authService;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto request)
        {
            _logger.LogInformation("Attempting login for user: {Email}", request.Email);

            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !_authService.ValidatePassword(request.Password, user.PasswordHash.Value))
            {
                _logger.LogWarning("Invalid login attempt for user: {Email}", request.Email);
                throw new InvalidCredentialsException("Invalid email or password");
            }

            var tokens = _tokenService.GenerateTokens(user);
            await _tokenService.PersistRefreshTokenAsync(tokens.RefreshToken);

            _logger.LogInformation("Login successful for user: {Email}", request.Email);

            return new LoginResponseDto
            {
                Token = tokens.JwtToken,
                RefreshToken = tokens.RefreshToken.Token,
                ExpiresAt = tokens.RefreshToken.ExpiresAt,
                User = UserMapper.ToDto(user)
            };
        }
    }
}
