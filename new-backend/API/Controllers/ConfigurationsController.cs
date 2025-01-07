using Application.UseCases.Configurations;
using Core.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IGetConfigurationsUseCase _getConfigurationsUseCase;
        private readonly IUpdateConfigurationUseCase _updateConfigurationUseCase;
        private readonly IDeleteConfigurationUseCase _deleteConfigurationUseCase;
        private readonly IGetConfigurationsWithFilterUseCase _getConfigurationsWithFilterUseCase;
        private readonly ILogger<ConfigurationsController> _logger;

        public ConfigurationsController(
            IGetConfigurationsUseCase getConfigurationsUseCase,
            IUpdateConfigurationUseCase updateConfigurationUseCase,
            IDeleteConfigurationUseCase deleteConfigurationUseCase,
            IGetConfigurationsWithFilterUseCase getConfigurationsWithFilterUseCase,
            ILogger<ConfigurationsController> logger)
        {
            _getConfigurationsUseCase = getConfigurationsUseCase;
            _updateConfigurationUseCase = updateConfigurationUseCase;
            _deleteConfigurationUseCase = deleteConfigurationUseCase;
            _getConfigurationsWithFilterUseCase = getConfigurationsWithFilterUseCase;
            _logger = logger;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all configurations", Description = "Fetches all configurations")]
        [SwaggerResponse(200, "Configurations retrieved successfully", typeof(List<ConfigurationDto>))]
        public async Task<IActionResult> ListConfigurations()
        {
            var configurations = await _getConfigurationsUseCase.ExecuteAsync();
            return ResponseHelper.CreateResponse("Configurations retrieved successfully", HttpStatusCode.OK, configurations);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update a configuration", Description = "Updates a configuration by its ID")]
        [SwaggerResponse(204, "Configuration updated successfully")]
        [SwaggerResponse(400, "Invalid update request")]
        public async Task<IActionResult> UpdateConfiguration(Guid id, [FromBody] UpdateConfigurationDto request)
        {
            await _updateConfigurationUseCase.ExecuteAsync(id, request);
            return ResponseHelper.CreateResponse("Configuration updated successfully", HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete a configuration", Description = "Deletes a configuration by its ID")]
        [SwaggerResponse(204, "Configuration deleted successfully")]
        [SwaggerResponse(404, "Configuration not found")]
        public async Task<IActionResult> DeleteConfiguration(Guid id)
        {
            try
            {
                await _deleteConfigurationUseCase.ExecuteAsync(id);
                return ResponseHelper.CreateResponse("Configuration deleted successfully", HttpStatusCode.NoContent);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Configuration not found for deletion");
                return ResponseHelper.CreateResponse(ex.Message, HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get configurations with filter", Description = "Fetches configurations using provided filters")]
        [SwaggerResponse(200, "Filtered configurations retrieved successfully", typeof(List<ConfigurationDto>))]
        [SwaggerResponse(400, "Invalid filter parameters")]
        public async Task<IActionResult> GetConfigurationsWithFilter([FromQuery] ConfigurationFilterDto filters)
        {
            try
            {
                var configurations = await _getConfigurationsWithFilterUseCase.ExecuteAsync(filters);
                return ResponseHelper.CreateResponse("Filtered configurations retrieved successfully", HttpStatusCode.OK, configurations);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid filter parameters provided");
                return ResponseHelper.CreateResponse(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }

}
