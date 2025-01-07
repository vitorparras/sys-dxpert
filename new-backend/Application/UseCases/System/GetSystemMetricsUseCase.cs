using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.System
{
    public interface IGetSystemMetricsUseCase
    {
        Task<SystemMetricsDto> ExecuteAsync();
    }

    public class GetSystemMetricsUseCase : IGetSystemMetricsUseCase
    {
        private readonly ISystemMetricsService _systemMetricsService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSystemMetricsUseCase> _logger;

        public GetSystemMetricsUseCase(
            ISystemMetricsService systemMetricsService,
            IMapper mapper,
            ILogger<GetSystemMetricsUseCase> logger)
        {
            _systemMetricsService = systemMetricsService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SystemMetricsDto> ExecuteAsync()
        {
            _logger.LogInformation("Fetching system metrics.");

            var metrics = await _systemMetricsService.GetSystemMetricsAsync();

            _logger.LogInformation("System metrics successfully retrieved.");

            return _mapper.Map<SystemMetricsDto>(metrics);
        }
    }
}
