using Core.Entities;

namespace Infrastructure.Persistence.Repositorys.interfaces
{
    public interface INotificationPreferencesRepository
    {
        Task<NotificationPreferences?> GetByUserIdAsync(Guid userId);
        Task CreateAsync(NotificationPreferences preferences);
        Task UpdateAsync(NotificationPreferences preferences);
        Task DeleteAsync(NotificationPreferences preferences);
    }
}
