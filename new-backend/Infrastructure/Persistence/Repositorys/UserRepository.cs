using Core.Entities;
using Infrastructure.Persistence.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly SysDbContext _context;

        public UserRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            return await _context.Users
                .Include(u => u.NotificationPreferences)
                .Include(u => u.LoginHistory)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.NotificationPreferences)
                .Include(u => u.LoginHistory)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.NotificationPreferences)
                .Include(u => u.LoginHistory)
                .Include(u => u.RefreshTokens)
                .ToListAsync();
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.Value == email);
        }
    }
}
