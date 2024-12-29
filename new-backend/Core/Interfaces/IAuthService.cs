using Core.Entities;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        bool ValidateToken(string token);
        RefreshToken GenerateRefreshToken(User user);
        bool ValidatePassword(string password, string passwordHash);
        string HashPassword(string password);
    }

}
