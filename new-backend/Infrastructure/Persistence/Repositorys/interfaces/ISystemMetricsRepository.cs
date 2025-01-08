using Core.Entities;

namespace Infrastructure.Persistence.Repositorys.interfaces
{
    public interface ISystemMetricsRepository
    {
        Task<List<SystemMetrics>> GetAllAsync();
        Task<SystemMetrics?> GetLatestAsync();
        Task CreateAsync(SystemMetrics systemMetrics);
    }
}
