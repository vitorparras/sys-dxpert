using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(Guid userId);
        Task<User> GetByEmailAsync(string email);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);
        Task<List<User>> GetAllUsersAsync();
    }
}
