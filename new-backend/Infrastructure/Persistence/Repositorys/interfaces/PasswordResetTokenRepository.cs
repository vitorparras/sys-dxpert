using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositorys.interfaces
{
    public class PasswordResetTokenRepository : IPasswordResetTokenRepository
    {
        private readonly SysDbContext _context;

        public PasswordResetTokenRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<PasswordResetToken?> GetByTokenAsync(string token)
        {
            return await _context.PasswordResetTokens
                .FirstOrDefaultAsync(prt => prt.Token == token);
        }

        public async Task CreateAsync(PasswordResetToken passwordResetToken)
        {
            await _context.PasswordResetTokens.AddAsync(passwordResetToken);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PasswordResetToken passwordResetToken)
        {
            _context.PasswordResetTokens.Update(passwordResetToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpiredTokensAsync()
        {
            var expiredTokens = await _context.PasswordResetTokens
                .Where(prt => prt.IsExpired())
                .ToListAsync();

            if (expiredTokens.Any())
            {
                _context.PasswordResetTokens.RemoveRange(expiredTokens);
                await _context.SaveChangesAsync();
            }
        }
    }
}
