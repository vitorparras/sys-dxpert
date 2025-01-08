using Microsoft.Extensions.Configuration;

namespace Core.Interfaces
{
    public interface IConfigurationService
    {
        Task<List<Configuration>> GetAllConfigurationsAsync();
        Task<Configuration> GetConfigurationByIdAsync(Guid id);
        Task AddConfigurationAsync(Configuration configuration);
        Task UpdateConfigurationAsync(Guid id, string key, string value);
        Task DeleteConfigurationAsync(Guid id);
    }
}
