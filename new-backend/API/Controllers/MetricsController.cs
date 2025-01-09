using API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MetricsController : ControllerBase
    {
        /*private readonly IGetSystemMetricsUseCase _getSystemMetricsUseCase;
        private readonly ILogger<MetricsController> _logger;

        public MetricsController(
            IGetSystemMetricsUseCase getSystemMetricsUseCase,
            ILogger<MetricsController> logger)
        {
            _getSystemMetricsUseCase = getSystemMetricsUseCase;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Fetch system metrics", Description = "Fetches overall system metrics")]
        [SwaggerResponse(200, "System metrics retrieved successfully", typeof(SystemMetricsDto))]
        [SwaggerResponse(500, "Internal server error occurred while fetching system metrics")]
        public async Task<IActionResult> GetSystemMetrics()
        {
            try
            {
                var metrics = await _getSystemMetricsUseCase.ExecuteAsync();
                return ResponseHelper.CreateResponse("System metrics retrieved successfully", HttpStatusCode.OK, metrics);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching system metrics");
                return ResponseHelper.CreateResponse("An error occurred while fetching system metrics.", HttpStatusCode.InternalServerError);
            }
        }*/
    }
}
