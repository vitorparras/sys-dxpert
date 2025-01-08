using Core.Entities;
using Infrastructure.Persistence.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositorys
{
    public class LoginHistoryRepository : ILoginHistoryRepository
    {
        private readonly SysDbContext _context;

        public LoginHistoryRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoginHistory>> GetByUserIdAsync(Guid userId)
        {
            return await _context.LoginHistory
                .Where(lh => lh.UserId == userId)
                .OrderByDescending(lh => lh.LoginDate)
                .ToListAsync();
        }

        public async Task CreateAsync(LoginHistory loginHistory)
        {
            await _context.LoginHistory.AddAsync(loginHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var loginHistory = await _context.LoginHistory.FindAsync(id);
            if (loginHistory != null)
            {
                _context.LoginHistory.Remove(loginHistory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
