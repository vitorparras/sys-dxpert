using Core.Entities;

namespace Infrastructure.Persistence.Repositorys.interfaces
{
    public interface IUserMetricsRepository
    {
        Task<UserMetrics?> GetByUserIdAsync(Guid userId);
        Task CreateAsync(UserMetrics userMetrics);
        Task UpdateAsync(UserMetrics userMetrics);
        Task DeleteAsync(UserMetrics userMetrics);
    }
}
