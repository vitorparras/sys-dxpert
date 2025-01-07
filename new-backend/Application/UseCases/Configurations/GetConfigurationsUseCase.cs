using AutoMapper;
using Core.Exceptions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Configurations
{
    public interface IGetConfigurationsUseCase
    {
        Task<List<ConfigurationDto>> ExecuteAsync();
    }

    public class GetConfigurationsUseCase : IGetConfigurationsUseCase
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetConfigurationsUseCase> _logger;

        public GetConfigurationsUseCase(
            IConfigurationRepository configurationRepository,
            IMapper mapper,
            ILogger<GetConfigurationsUseCase> logger)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ConfigurationDto>> ExecuteAsync()
        {
            _logger.LogInformation("Fetching all system configurations.");

            var configurations = await _configurationRepository.GetAllAsync();
            if (configurations == null || !configurations.Any())
            {
                _logger.LogWarning("No configurations found.");
                throw new ConfigurationNotFoundException("No configurations found.");
            }

            _logger.LogInformation("{Count} configurations retrieved successfully.", configurations.Count);

            return _mapper.Map<List<ConfigurationDto>>(configurations);
        }
    }
}
