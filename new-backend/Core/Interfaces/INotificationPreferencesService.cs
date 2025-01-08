namespace Core.Interfaces
{
    public interface INotificationPreferencesService
    {
        Task<NotificationPreferences> GetNotificationPreferencesAsync(Guid userId);
        Task UpdateNotificationPreferencesAsync(Guid userId, NotificationPreferences preferences);
    }
}
