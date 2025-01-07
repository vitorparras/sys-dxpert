using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Notifications
{
    public interface IUpdateNotificationPreferencesUseCase
    {
        Task ExecuteAsync(Guid userId, UpdateNotificationPreferencesDto request);
    }

    public class UpdateNotificationPreferencesUseCase : IUpdateNotificationPreferencesUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateNotificationPreferencesUseCase> _logger;

        public UpdateNotificationPreferencesUseCase(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<UpdateNotificationPreferencesUseCase> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task ExecuteAsync(Guid userId, UpdateNotificationPreferencesDto request)
        {
            _logger.LogInformation("Updating notification preferences for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("Notification preferences update failed: user not found (ID: {UserId})", userId);
                throw new UserNotFoundException("User not found.");
            }

            user.UpdateNotificationPreferences(
                request.EmailNotificationsEnabled,
                request.SmsNotificationsEnabled,
                request.PushNotificationsEnabled
            );

            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Notification preferences updated successfully for user ID: {UserId}", userId);
        }
    }
}
