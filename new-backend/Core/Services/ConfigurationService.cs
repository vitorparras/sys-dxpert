using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly ILogger<ConfigurationService> _logger;

        public ConfigurationService(IConfigurationRepository configurationRepository, ILogger<ConfigurationService> logger)
        {
            _configurationRepository = configurationRepository;
            _logger = logger;
        }

        public async Task<List<Configuration>> GetAllConfigurationsAsync()
        {
            _logger.LogInformation("Fetching all configurations from the system.");

            var configurations = await _configurationRepository.GetAllAsync();
            if (configurations == null || !configurations.Any())
            {
                _logger.LogWarning("No configurations found in the system.");
                throw new ConfigurationNotFoundException("No configurations were found.");
            }

            _logger.LogInformation("{Count} configurations retrieved successfully.", configurations.Count);
            return configurations;
        }

        public async Task<Configuration> GetConfigurationByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching configuration with ID: {ConfigurationId}", id);

            var configuration = await _configurationRepository.GetByIdAsync(id);
            if (configuration == null)
            {
                _logger.LogWarning("Configuration not found for ID: {ConfigurationId}", id);
                throw new ConfigurationNotFoundException($"Configuration with ID {id} not found.");
            }

            _logger.LogInformation("Configuration with ID: {ConfigurationId} retrieved successfully.", id);
            return configuration;
        }

        public async Task AddConfigurationAsync(Configuration configuration)
        {
            _logger.LogInformation("Adding a new configuration with Key: {Key}", configuration.Key);

            var existingConfiguration = await _configurationRepository.GetByKeyAsync(configuration.Key);
            if (existingConfiguration != null)
            {
                _logger.LogWarning("Configuration with Key: {Key} already exists.", configuration.Key);
                throw new ConflictException($"A configuration with the key '{configuration.Key}' already exists.");
            }

            await _configurationRepository.CreateAsync(configuration);
            _logger.LogInformation("Configuration with Key: {Key} added successfully.", configuration.Key);
        }

        public async Task UpdateConfigurationAsync(Guid id, string key, string value)
        {
            _logger.LogInformation("Updating configuration with ID: {ConfigurationId}", id);

            var configuration = await _configurationRepository.GetByIdAsync(id);
            if (configuration == null)
            {
                _logger.LogWarning("Failed to update: Configuration not found with ID: {ConfigurationId}", id);
                throw new ConfigurationNotFoundException($"Configuration with ID {id} not found.");
            }

            configuration.Update(key, value);
            await _configurationRepository.UpdateAsync(configuration);

            _logger.LogInformation("Configuration with ID: {ConfigurationId} updated successfully.", id);
        }

        public async Task DeleteConfigurationAsync(Guid id)
        {
            _logger.LogInformation("Deleting configuration with ID: {ConfigurationId}", id);

            var configuration = await _configurationRepository.GetByIdAsync(id);
            if (configuration == null)
            {
                _logger.LogWarning("Failed to delete: Configuration not found with ID: {ConfigurationId}", id);
                throw new ConfigurationNotFoundException($"Configuration with ID {id} not found.");
            }

            await _configurationRepository.DeleteAsync(configuration);
            _logger.LogInformation("Configuration with ID: {ConfigurationId} deleted successfully.", id);
        }
    }
}
