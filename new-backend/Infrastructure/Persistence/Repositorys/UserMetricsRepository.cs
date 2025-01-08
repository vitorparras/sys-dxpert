using Core.Entities;
using Infrastructure.Persistence.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositorys
{
    public class UserMetricsRepository : IUserMetricsRepository
    {
        private readonly SysDbContext _context;

        public UserMetricsRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<UserMetrics?> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserMetrics
                .FirstOrDefaultAsync(um => um.UserId == userId);
        }

        public async Task CreateAsync(UserMetrics userMetrics)
        {
            await _context.UserMetrics.AddAsync(userMetrics);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserMetrics userMetrics)
        {
            _context.UserMetrics.Update(userMetrics);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserMetrics userMetrics)
        {
            _context.UserMetrics.Remove(userMetrics);
            await _context.SaveChangesAsync();
        }
    }
}
