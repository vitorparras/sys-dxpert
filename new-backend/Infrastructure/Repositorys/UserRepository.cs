using Domain.Entities;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositorys
{
    /// <summary>
    /// Repository for handling user-related data persistence and retrieval operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly SysDbContext _context;
        private readonly IValidator<User> _validator;
        private readonly ILogger<UserRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">Database context for EF Core.</param>
        /// <param name="validator">FluentValidation validator for user entity.</param>
        /// <param name="logger">Logger for observability.</param>
        public UserRepository(SysDbContext context, IValidator<User> validator, ILogger<UserRepository> logger)
        {
            _context = context;
            _validator = validator;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new user to the database after validating the entity.
        /// </summary>
        /// <param name="user">User entity to be added.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="ValidationException">Thrown if the entity fails validation.</exception>
        public async Task AddAsync(User user)
        {
            _logger.LogInformation("Adding a new user: {Email}", user.Email.Value);

            var validationResult = await _validator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Validation failed: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            _logger.LogInformation("User successfully added with email: {Email}", user.Email.Value);
        }

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier (GUID) of the user.</param>
        /// <returns>The user entity or null if not found.</returns>
        public async Task<User?> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching user by ID: {UserId}", id);
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>The user entity or null if not found.</returns>
        public async Task<User?> GetByEmailAsync(string email)
        {
            _logger.LogInformation("Fetching user by email: {Email}", email);
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        /// <summary>
        /// Updates an existing user entity after validating its state.
        /// </summary>
        /// <param name="user">The user entity to update.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <exception cref="ValidationException">Thrown if the entity fails validation.</exception>
        public async Task UpdateAsync(User user)
        {
            _logger.LogInformation("Updating user: {Email}", user.Email.Value);

            var validationResult = await _validator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Validation failed during update: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            _logger.LogInformation("User successfully updated: {Email}", user.Email.Value);
        }

        /// <summary>
        /// Deletes a user entity from the database.
        /// </summary>
        /// <param name="user">The user entity to delete.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(User user)
        {
            _logger.LogInformation("Deleting user: {Email}", user.Email.Value);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            _logger.LogInformation("User successfully deleted: {Email}", user.Email.Value);
        }

        /// <summary>
        /// Checks if a user with the specified email already exists in the database.
        /// </summary>
        /// <param name="email">The email address to check.</param>
        /// <returns>True if the email exists, otherwise false.</returns>
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            _logger.LogInformation("Checking if email exists: {Email}", email);
            return await _context.Users.AnyAsync(u => u.Email.Value == email);
        }

        /// <summary>
        /// Retrieves a user associated with a valid refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token associated with the user.</param>
        /// <returns>The user entity or null if no valid refresh token is found.</returns>
        public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
        {
            _logger.LogInformation("Fetching user by refresh token.");

            var user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.Token == refreshToken));

            if (user == null)
            {
                _logger.LogWarning("No user found with the provided refresh token.");
            }
            else
            {
                _logger.LogInformation("User found for the provided refresh token: {UserId}", user.Id);
            }

            return user;
        }
    }
}
