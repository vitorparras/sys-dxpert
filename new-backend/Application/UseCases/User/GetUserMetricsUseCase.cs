using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.User
{
    public interface IGetUserMetricsUseCase
    {
        Task<UserMetricsDto> ExecuteAsync(Guid userId);
    }

    public class GetUserMetricsUseCase : IGetUserMetricsUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMetricsService _userMetricsService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserMetricsUseCase> _logger;

        public GetUserMetricsUseCase(
            IUserRepository userRepository,
            IUserMetricsService userMetricsService,
            IMapper mapper,
            ILogger<GetUserMetricsUseCase> logger)
        {
            _userRepository = userRepository;
            _userMetricsService = userMetricsService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserMetricsDto> ExecuteAsync(Guid userId)
        {
            _logger.LogInformation("Fetching user metrics for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("User metrics request failed: user not found (ID: {UserId})", userId);
                throw new UserNotFoundException("User not found.");
            }

            var metrics = await _userMetricsService.CalculateMetricsAsync(user);

            _logger.LogInformation("User metrics successfully calculated for user ID: {UserId}", userId);

            return _mapper.Map<UserMetricsDto>(metrics);
        }
    }
}
