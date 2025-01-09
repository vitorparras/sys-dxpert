using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        TokenResponse GenerateToken(User user);
        Task PersistRefreshTokenAsync(RefreshToken refreshToken, Guid userId);
        Task<bool> ValidateRefreshTokenAsync(Guid userId, string refreshToken);
        bool ValidateToken(string token);
    }
}
