using Core.Entities;

namespace Infrastructure.Persistence.Repositorys.interfaces
{
    public interface ILoginHistoryRepository
    {
        Task<List<LoginHistory>> GetByUserIdAsync(Guid userId);
        Task CreateAsync(LoginHistory loginHistory);
        Task DeleteAsync(Guid id);
    }
}
