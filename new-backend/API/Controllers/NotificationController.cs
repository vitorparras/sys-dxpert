using Application.Commands.Notification;
using Application.DTOs;
using Application.Queries.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(IMediator mediator, ILogger<NotificationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Fetches the current notification preferences for the authenticated user.
        /// </summary>
        [HttpGet("preferences/{userId:guid}")]
        [SwaggerOperation(Summary = "Get Notification Preferences", Description = "Fetch the notification preferences of the authenticated user.")]
        [SwaggerResponse(200, "Notification preferences retrieved successfully.", typeof(NotificationPreferencesDto))]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetNotificationPreferences(Guid userId)
        {
            _logger.LogInformation("API call to get notification preferences for UserId: {UserId}", userId);
            var response = await _mediator.Send(new GetNotificationPreferencesQuery(userId));
            return Ok(response);

        }

        /// <summary>
        /// Update the notification preferences for the authenticated user.
        /// </summary>
        [HttpPut("preferences/{userId:guid}")]
        [SwaggerOperation(Summary = "Update Notification Preferences", Description = "Update the notification preferences of the authenticated user.")]
        [SwaggerResponse(204, "Notification preferences updated successfully.")]
        [SwaggerResponse(400, "Invalid request data.")]
        [SwaggerResponse(401, "Unauthorized.")]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> UpdateNotificationPreferences(Guid userId, [FromBody] UpdateNotificationPreferencesDto request)
        {
            _logger.LogInformation("API call to update notification preferences for UserId: {UserId}", userId);

            var command = new UpdateNotificationPreferencesCommand(userId, request);
            await _mediator.Send(command);

            _logger.LogInformation("Notification preferences updated successfully for UserId: {UserId}", userId);
            return NoContent();

        }
    }
}
