using Application.DTOs;
using Application.Handlers;
using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Login
{
    public interface ILoginUserUseCase
    {
        Task<LoginResponseDto> ExecuteAsync(LoginRequestDto request);
    }

    public class LoginUserUseCase : ILoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IAuditService _auditService;
        private readonly ILogger<LoginUserUseCase> _logger;
        private readonly IMapper _mapper;
        private readonly LoginFailureHandler _loginFailureHandler;

        public LoginUserUseCase(
            IUserRepository userRepository,
            IAuthService authService,
            ITokenService tokenService,
            IAuditService auditService,
            ILogger<LoginUserUseCase> logger,
            IMapper mapper,
            LoginFailureHandler loginFailureHandler)
        {
            _userRepository = userRepository;
            _authService = authService;
            _tokenService = tokenService;
            _auditService = auditService;
            _logger = logger;
            _mapper = mapper;
            _loginFailureHandler = loginFailureHandler;
        }

        public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto request)
        {
            _logger.LogInformation("Login attempt started for email: {Email}", request.Email);

            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                await _loginFailureHandler.HandleInvalidLoginAttemptAsync(request.Email);
                throw new InvalidCredentialsException("Invalid email or password.");
            }

            var isPasswordValid = _authService.ValidatePassword(request.Password, user.PasswordHash.Value);
            if (!isPasswordValid)
            {
                await _loginFailureHandler.HandleInvalidLoginAttemptAsync(request.Email);
                throw new InvalidCredentialsException("Invalid email or password.");
            }

            var tokens = _tokenService.GenerateTokens(user);

            await _tokenService.PersistRefreshTokenAsync(tokens.RefreshToken);

            await _auditService.RecordLoginSuccess(user.Id);

            _logger.LogInformation("Login successful for user ID: {UserId}, email: {Email}", user.Id, request.Email);

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
