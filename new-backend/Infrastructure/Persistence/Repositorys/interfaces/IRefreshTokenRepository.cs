using Core.Entities;

namespace Infrastructure.Persistence.Repositorys.interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task<List<RefreshToken>> GetByUserIdAsync(Guid userId);
        Task CreateAsync(RefreshToken refreshToken);
        Task DeleteAsync(RefreshToken refreshToken);
        Task DeleteExpiredTokensAsync();
    }
}
