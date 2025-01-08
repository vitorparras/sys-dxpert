using Core.Entities;
using Infrastructure.Persistence.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositorys
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly SysDbContext _context;

        public ConfigurationRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<List<Configuration>> GetAllAsync()
        {
            return await _context.Configurations.ToListAsync();
        }

        public async Task<Configuration?> GetByIdAsync(Guid id)
        {
            return await _context.Configurations
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Configuration?> GetByKeyAsync(string key)
        {
            return await _context.Configurations
                .FirstOrDefaultAsync(c => c.Key == key);
        }

        public async Task CreateAsync(Configuration configuration)
        {
            await _context.Configurations.AddAsync(configuration);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Configuration configuration)
        {
            _context.Configurations.Update(configuration);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Configuration configuration)
        {
            _context.Configurations.Remove(configuration);
            await _context.SaveChangesAsync();
        }
    }
}
