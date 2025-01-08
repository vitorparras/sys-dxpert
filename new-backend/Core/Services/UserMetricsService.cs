using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class UserMetricsService : IUserMetricsService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserMetricsService> _logger;

        public UserMetricsService(IUserRepository userRepository, ILogger<UserMetricsService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UserMetrics> CalculateMetricsAsync(Guid userId)
        {
            _logger.LogInformation("Calculating metrics for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("User metrics calculation failed: User not found (ID: {UserId})", userId);
                throw new UserNotFoundException($"User with ID {userId} not found.");
            }

            var metrics = new UserMetrics
            {
                TotalLogins = user.LoginHistory.Count,
                LastLoginDate = user.LoginHistory.OrderByDescending(l => l.Date).FirstOrDefault()?.Date,
                TotalPosts = user.Posts.Count,
                AccountAgeInDays = (DateTime.UtcNow - user.CreatedAt).Days
            };

            _logger.LogInformation("Metrics successfully calculated for user ID: {UserId}", userId);
            return metrics;
        }
    }
}
