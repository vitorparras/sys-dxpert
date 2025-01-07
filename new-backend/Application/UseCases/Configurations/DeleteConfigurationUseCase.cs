using Application.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Configurations
{
    public interface IDeleteConfigurationUseCase
    {
        Task ExecuteAsync(Guid id);
    }

    public class DeleteConfigurationUseCase : IDeleteConfigurationUseCase
    {
        private readonly IConfigurationService _configurationService;
        private readonly ILogger<DeleteConfigurationUseCase> _logger;

        public DeleteConfigurationUseCase(
            IConfigurationService configurationService,
            ILogger<DeleteConfigurationUseCase> logger)
        {
            _configurationService = configurationService;
            _logger = logger;
        }

        public async Task ExecuteAsync(Guid id)
        {
            _logger.LogInformation("Initiating deletion of configuration with ID: {ConfigurationId}", id);

            await _configurationService.DeleteConfigurationAsync(id);

            _logger.LogInformation("Configuration successfully deleted with ID: {ConfigurationId}", id);
        }
    }
}
