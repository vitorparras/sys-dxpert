using Application.DTOs;
using AutoMapper;
using Domain.ValueObjects;
using Infrastructure.Repositorys.interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Notification
{
    public record UpdateNotificationPreferencesCommand(Guid UserId, UpdateNotificationPreferencesDto Preferences) : IRequest;

    public class UpdateNotificationPreferencesHandler : IRequestHandler<UpdateNotificationPreferencesCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateNotificationPreferencesHandler> _logger;

        public UpdateNotificationPreferencesHandler(IUserRepository userRepository, IMapper mapper, ILogger<UpdateNotificationPreferencesHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateNotificationPreferencesCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating notification preferences for UserId: {UserId}", request.UserId);

            var user = await _userRepository.GetCurrentUserAsync(request.UserId);
            if (user == null)
            {
                _logger.LogWarning("User not found for UserId: {UserId}", request.UserId);
                throw new UnauthorizedAccessException("User not authenticated.");
            }

            var updatedPreferences = _mapper.Map<NotificationPreferences>(request.Preferences);

            user.UpdateNotificationPreferences(updatedPreferences);
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Notification preferences updated successfully for UserId: {UserId}", request.UserId);
        }
    }
}
