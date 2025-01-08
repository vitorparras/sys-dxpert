using Core.Entities;
using Infrastructure.Persistence.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositorys
{
    public class NotificationPreferencesRepository : INotificationPreferencesRepository
    {
        private readonly SysDbContext _context;

        public NotificationPreferencesRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<NotificationPreferences?> GetByUserIdAsync(Guid userId)
        {
            return await _context.NotificationPreferences
                .FirstOrDefaultAsync(np => np.UserId == userId);
        }

        public async Task CreateAsync(NotificationPreferences preferences)
        {
            await _context.NotificationPreferences.AddAsync(preferences);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NotificationPreferences preferences)
        {
            _context.NotificationPreferences.Update(preferences);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(NotificationPreferences preferences)
        {
            _context.NotificationPreferences.Remove(preferences);
            await _context.SaveChangesAsync();
        }
    }
}
