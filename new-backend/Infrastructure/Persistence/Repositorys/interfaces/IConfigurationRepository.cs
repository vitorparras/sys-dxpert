using Core.Entities;

namespace Infrastructure.Persistence.Repositorys.interfaces
{
    public interface IConfigurationRepository
    {
        Task<List<Configuration>> GetAllAsync();
        Task<Configuration?> GetByIdAsync(Guid id);
        Task<Configuration?> GetByKeyAsync(string key);
        Task CreateAsync(Configuration configuration);
        Task UpdateAsync(Configuration configuration);
        Task DeleteAsync(Configuration configuration);
    }
}
