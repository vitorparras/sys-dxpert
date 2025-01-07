using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Notifications
{
    public interface IGetNotificationPreferencesUseCase
    {
        Task<NotificationPreferencesDto> ExecuteAsync(Guid userId);
    }

    public class GetNotificationPreferencesUseCase : IGetNotificationPreferencesUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetNotificationPreferencesUseCase> _logger;

        public GetNotificationPreferencesUseCase(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<GetNotificationPreferencesUseCase> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<NotificationPreferencesDto> ExecuteAsync(Guid userId)
        {
            _logger.LogInformation("Fetching notification preferences for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("Notification preferences request failed: user not found (ID: {UserId})", userId);
                throw new UserNotFoundException("User not found.");
            }

            if (user.NotificationPreferences == null)
            {
                _logger.LogWarning("User notification preferences not found for user ID: {UserId}", userId);
                throw new NotificationPreferencesNotFoundException("Notification preferences not set.");
            }

            _logger.LogInformation("Notification preferences successfully retrieved for user ID: {UserId}", userId);

            return _mapper.Map<NotificationPreferencesDto>(user.NotificationPreferences);
        }
    }
}
