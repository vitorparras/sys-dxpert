using Core.Entities;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        bool ValidatePassword(string password, string passwordHash);
        string HashPassword(string password);
    }
}

