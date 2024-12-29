using Core.Entities;

namespace Core.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> CreateAsync(RefreshToken refreshToken);
        Task<RefreshToken> GetByTokenAsync(string token);
        Task DeleteAsync(RefreshToken refreshToken);
    }
}
