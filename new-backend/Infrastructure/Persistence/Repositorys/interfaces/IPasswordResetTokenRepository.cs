using Core.Entities;

namespace Infrastructure.Persistence.Repositorys.interfaces
{
    public interface IPasswordResetTokenRepository
    {
        Task<PasswordResetToken?> GetByTokenAsync(string token);
        Task CreateAsync(PasswordResetToken passwordResetToken);
        Task UpdateAsync(PasswordResetToken passwordResetToken);
        Task DeleteExpiredTokensAsync();
    }
}
