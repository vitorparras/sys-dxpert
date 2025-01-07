using Microsoft.Extensions.Logging;

namespace Application.UseCases.Configurations
{
    public interface IUpdateConfigurationUseCase
    {
        Task ExecuteAsync(Guid id, UpdateConfigurationDto request);
    }

    public class UpdateConfigurationUseCase : IUpdateConfigurationUseCase
    {
        private readonly IConfigurationService _configurationService;
        private readonly ILogger<UpdateConfigurationUseCase> _logger;

        public UpdateConfigurationUseCase(
            IConfigurationService configurationService,
            ILogger<UpdateConfigurationUseCase> logger)
        {
            _configurationService = configurationService;
            _logger = logger;
        }

        public async Task ExecuteAsync(Guid id, UpdateConfigurationDto request)
        {
            _logger.LogInformation("Updating configuration with ID: {ConfigurationId}", id);

            await _configurationService.UpdateConfigurationAsync(id, request.Key, request.Value);

            _logger.LogInformation("Configuration successfully updated with ID: {ConfigurationId}", id);
        }
    }
}
