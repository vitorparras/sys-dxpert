using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            _logger.LogInformation("Fetching user with ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("User not found with ID: {UserId}", userId);
                throw new UserNotFoundException($"User with ID {userId} not found.");
            }

            _logger.LogInformation("User with ID: {UserId} successfully retrieved.", userId);
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                _logger.LogWarning("Attempted to fetch user with empty email.");
                throw new ArgumentException("Email cannot be empty.");
            }

            _logger.LogInformation("Fetching user with Email: {Email}", email);

            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning("User not found with Email: {Email}", email);
                throw new UserNotFoundException($"User with email {email} not found.");
            }

            _logger.LogInformation("User with Email: {Email} successfully retrieved.", email);
            return user;
        }

        public async Task CreateUserAsync(User user)
        {
            _logger.LogInformation("Initiating user creation for Email: {Email}", user.Email.Value);

            var existingUser = await _userRepository.GetByEmailAsync(user.Email.Value);
            if (existingUser != null)
            {
                _logger.LogWarning("User creation failed: Email already exists ({Email})", user.Email.Value);
                throw new ConflictException("A user with this email already exists.");
            }

            await _userRepository.CreateAsync(user);
            _logger.LogInformation("User with Email: {Email} created successfully.", user.Email.Value);
        }

        public async Task UpdateUserAsync(User user)
        {
            _logger.LogInformation("Initiating update for user ID: {UserId}", user.Id);

            var existingUser = await _userRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
            {
                _logger.LogWarning("User update failed: User not found (ID: {UserId})", user.Id);
                throw new UserNotFoundException($"User with ID {user.Id} not found.");
            }

            await _userRepository.UpdateAsync(user);
            _logger.LogInformation("User with ID: {UserId} updated successfully.", user.Id);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            _logger.LogInformation("Initiating deletion of user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("User deletion failed: User not found (ID: {UserId})", userId);
                throw new UserNotFoundException($"User with ID {userId} not found.");
            }

            await _userRepository.DeleteAsync(user);
            _logger.LogInformation("User with ID: {UserId} deleted successfully.", userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            _logger.LogInformation("Fetching all users from the system.");

            var users = await _userRepository.GetAllAsync();
            if (users == null || !users.Any())
            {
                _logger.LogWarning("No users found in the system.");
                throw new UserNotFoundException("No users were found.");
            }

            _logger.LogInformation("{UserCount} users retrieved successfully.", users.Count);
            return users;
        }
    }
}
