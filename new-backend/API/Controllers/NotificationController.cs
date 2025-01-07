using Application.UseCases.Notifications;
using Core.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NotificationController : ControllerBase
    {
        private readonly IGetNotificationPreferencesUseCase _getNotificationPreferencesUseCase;
        private readonly IUpdateNotificationPreferencesUseCase _updateNotificationPreferencesUseCase;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(
            IGetNotificationPreferencesUseCase getNotificationPreferencesUseCase,
            IUpdateNotificationPreferencesUseCase updateNotificationPreferencesUseCase,
            ILogger<NotificationController> logger)
        {
            _getNotificationPreferencesUseCase = getNotificationPreferencesUseCase;
            _updateNotificationPreferencesUseCase = updateNotificationPreferencesUseCase;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get notification preferences", Description = "Fetches the notification preferences of the logged-in user")]
        [SwaggerResponse(200, "Notification preferences retrieved successfully", typeof(NotificationPreferencesDto))]
        public async Task<IActionResult> GetNotificationPreferences()
        {
            try
            {
                var preferences = await _getNotificationPreferencesUseCase.ExecuteAsync();
                return ResponseHelper.CreateResponse("Notification preferences retrieved successfully", HttpStatusCode.OK, preferences);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching notification preferences");
                return ResponseHelper.CreateResponse("An error occurred while fetching notification preferences.", HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update notification preferences", Description = "Updates the notification preferences of the logged-in user")]
        [SwaggerResponse(204, "Notification preferences updated successfully")]
        public async Task<IActionResult> UpdateNotificationPreferences([FromBody] UpdateNotificationPreferencesDto request)
        {
            try
            {
                await _updateNotificationPreferencesUseCase.ExecuteAsync(request);
                return ResponseHelper.CreateResponse("Notification preferences updated successfully", HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating notification preferences");
                return ResponseHelper.CreateResponse("An error occurred while updating notification preferences.", HttpStatusCode.InternalServerError);
            }
        }
    }

}
