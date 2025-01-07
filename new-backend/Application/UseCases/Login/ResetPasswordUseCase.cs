using Application.DTOs;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Login
{
    public interface IResetPasswordUseCase
    {
        Task ExecuteAsync(ResetPasswordDto request);
    }

    public class ResetPasswordUseCase : IResetPasswordUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly ILogger<ResetPasswordUseCase> _logger;

        public ResetPasswordUseCase(
            IUserRepository userRepository,
            IAuthService authService,
            ILogger<ResetPasswordUseCase> logger)
        {
            _userRepository = userRepository;
            _authService = authService;
            _logger = logger;
        }

        public async Task ExecuteAsync(ResetPasswordDto request)
        {
            _logger.LogInformation("Password reset initiated for email: {Email}", request.Email);

            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                _logger.LogWarning("Password reset attempted for non-existent email: {Email}", request.Email);
                throw new UserNotFoundException("Invalid or expired password reset token.");
            }

            if (!user.IsPasswordResetTokenValid(request.ResetToken))
            {
                _logger.LogWarning("Invalid or expired password reset token for email: {Email}", request.Email);
                throw new InvalidPasswordResetTokenException("Invalid or expired password reset token.");
            }

            if (!_authService.IsPasswordComplexEnough(request.NewPassword))
            {
                _logger.LogWarning("Password reset failed for email: {Email} due to weak password.", request.Email);
                throw new WeakPasswordException("The new password does not meet the complexity requirements.");
            }

            var newPasswordHash = _authService.HashPassword(request.NewPassword);
            user.UpdatePassword(Core.ValueObjects.PasswordHash.Create(newPasswordHash));

            user.ClearPasswordResetToken();
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Password reset successful for email: {Email}", request.Email);
        }
    }
}
