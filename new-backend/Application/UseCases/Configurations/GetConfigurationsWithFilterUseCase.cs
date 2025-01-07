using AutoMapper;
using Core.Exceptions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Configurations
{
    public interface IGetConfigurationsWithFilterUseCase
    {
        Task<List<ConfigurationDto>> ExecuteAsync(ConfigurationFilterDto filters);
    }

    public class GetConfigurationsWithFilterUseCase : IGetConfigurationsWithFilterUseCase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetConfigurationsWithFilterUseCase> _logger;

        public GetConfigurationsWithFilterUseCase(
            IConfigurationService configurationService,
            IMapper mapper,
            ILogger<GetConfigurationsWithFilterUseCase> logger)
        {
            _configurationService = configurationService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ConfigurationDto>> ExecuteAsync(ConfigurationFilterDto filters)
        {
            _logger.LogInformation("Fetching configurations with filters applied.");

            var configurations = await _configurationService.GetConfigurationsByFilterAsync(filters);

            if (!configurations.Any())
            {
                _logger.LogWarning("No configurations found for the provided filters.");
                throw new ConfigurationNotFoundException("No configurations matched the provided filters.");
            }

            _logger.LogInformation("{Count} configurations retrieved successfully.", configurations.Count);

            return _mapper.Map<List<ConfigurationDto>>(configurations);
        }
    }
}
