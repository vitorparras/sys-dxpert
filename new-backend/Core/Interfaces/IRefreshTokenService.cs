using Core.Entities;

namespace Core.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> GenerateRefreshTokenAsync(User user);
        Task ValidateRefreshTokenAsync(string token);
        Task RevokeRefreshTokenAsync(string token);
    }
}
