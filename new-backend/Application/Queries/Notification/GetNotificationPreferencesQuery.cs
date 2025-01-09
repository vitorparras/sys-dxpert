using Application.DTOs;
using AutoMapper;
using Infrastructure.Repositorys.interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.Notification
{
    public record GetNotificationPreferencesQuery(Guid UserId) : IRequest<NotificationPreferencesDto>;

    public class GetNotificationPreferencesHandler : IRequestHandler<GetNotificationPreferencesQuery, NotificationPreferencesDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetNotificationPreferencesHandler> _logger;

        public GetNotificationPreferencesHandler(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<GetNotificationPreferencesHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<NotificationPreferencesDto> Handle(GetNotificationPreferencesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching notification preferences for UserId: {UserId}", request.UserId);

            var user = await _userRepository.GetCurrentUserAsync(request.UserId);
            if (user == null)
            {
                _logger.LogWarning("User not found for UserId: {UserId}", request.UserId);
                throw new UnauthorizedAccessException("User not authenticated.");
            }

            return _mapper.Map<NotificationPreferencesDto>(user.NotificationPreferences);
        }
    }
}
