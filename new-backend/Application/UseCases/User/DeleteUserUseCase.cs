using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.User
{
    public interface IDeleteUserUseCase
    {
        Task ExecuteAsync(Guid userId);
    }

    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<DeleteUserUseCase> _logger;

        public DeleteUserUseCase(IUserRepository userRepository, ILogger<DeleteUserUseCase> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task ExecuteAsync(Guid userId)
        {
            _logger.LogInformation("Starting user deletion for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("User deletion failed: user not found (ID: {UserId})", userId);
                throw new UserNotFoundException("User not found.");
            }

            await _userRepository.DeleteAsync(user);

            _logger.LogInformation("User successfully deleted with ID: {UserId}", userId);
        }
    }
}
