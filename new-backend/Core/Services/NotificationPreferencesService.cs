using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class NotificationPreferencesService : INotificationPreferencesService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<NotificationPreferencesService> _logger;

        public NotificationPreferencesService(IUserRepository userRepository, ILogger<NotificationPreferencesService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<NotificationPreferences> GetNotificationPreferencesAsync(Guid userId)
        {
            _logger.LogInformation("Fetching notification preferences for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("User not found when fetching notification preferences (ID: {UserId})", userId);
                throw new UserNotFoundException("User not found.");
            }

            _logger.LogInformation("Notification preferences retrieved successfully for user ID: {UserId}", userId);
            return user.NotificationPreferences;
        }

        public async Task UpdateNotificationPreferencesAsync(Guid userId, NotificationPreferences preferences)
        {
            _logger.LogInformation("Updating notification preferences for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("User not found when attempting to update preferences (ID: {UserId})", userId);
                throw new UserNotFoundException("User not found.");
            }

            user.UpdateNotificationPreferences(
                preferences.EmailNotificationsEnabled,
                preferences.SmsNotificationsEnabled,
                preferences.PushNotificationsEnabled
            );

            await _userRepository.UpdateAsync(user);
            _logger.LogInformation("Notification preferences updated successfully for user ID: {UserId}", userId);
        }
    }
}
