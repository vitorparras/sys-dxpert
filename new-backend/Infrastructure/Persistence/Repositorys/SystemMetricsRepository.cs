using Core.Entities;
using Infrastructure.Persistence.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositorys
{
    public class SystemMetricsRepository : ISystemMetricsRepository
    {
        private readonly SysDbContext _context;

        public SystemMetricsRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<List<SystemMetrics>> GetAllAsync()
        {
            return await _context.SystemMetrics.ToListAsync();
        }

        public async Task<SystemMetrics?> GetLatestAsync()
        {
            return await _context.SystemMetrics
                .OrderByDescending(sm => sm.CollectedAt)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(SystemMetrics systemMetrics)
        {
            await _context.SystemMetrics.AddAsync(systemMetrics);
            await _context.SaveChangesAsync();
        }
    }
}
