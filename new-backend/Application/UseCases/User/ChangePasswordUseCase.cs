using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.User
{
    public interface IChangePasswordUseCase
    {
        Task ExecuteAsync(Guid userId, string currentPassword, string newPassword);
    }

    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly ILogger<ChangePasswordUseCase> _logger;

        public ChangePasswordUseCase(
            IUserRepository userRepository,
            IAuthService authService,
            ILogger<ChangePasswordUseCase> logger)
        {
            _userRepository = userRepository;
            _authService = authService;
            _logger = logger;
        }

        public async Task ExecuteAsync(Guid userId, string currentPassword, string newPassword)
        {
            _logger.LogInformation("Password change initiated for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("Password change failed: user not found (ID: {UserId})", userId);
                throw new UserNotFoundException("User not found.");
            }

            if (!_authService.ValidatePassword(currentPassword, user.PasswordHash.Value))
            {
                _logger.LogWarning("Password change failed: incorrect current password for user ID: {UserId}", userId);
                throw new InvalidCurrentPasswordException("Current password is incorrect.");
            }

            if (!_authService.IsPasswordComplexEnough(newPassword))
            {
                _logger.LogWarning("Password change failed: new password is too weak for user ID: {UserId}", userId);
                throw new WeakPasswordException("The new password does not meet the complexity requirements.");
            }

            var newPasswordHash = _authService.HashPassword(newPassword);
            user.UpdatePassword(Core.ValueObjects.PasswordHash.Create(newPasswordHash));

            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Password change successful for user ID: {UserId}", userId);
        }
    }
}
