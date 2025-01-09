using Domain.Entities;

namespace Infrastructure.Repositorys.interfaces
{
    /// <summary>
    /// Defines the contract for user repository operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        Task<User?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        Task<User?> GetByEmailAsync(string email);

        /// <summary>
        /// Retrieves a user by their Refresh Token.
        /// </summary>
        Task<User?> GetByRefreshTokenAsync(string refreshToken);

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        Task AddAsync(User user);

        /// <summary>
        /// Updates an existing user entity.
        /// </summary>
        Task UpdateAsync(User user);

        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        Task DeleteAsync(User user);

        /// <summary>
        /// Checks if a user exists by their email address.
        /// </summary>
        Task<bool> ExistsByEmailAsync(string email);
    }
}
