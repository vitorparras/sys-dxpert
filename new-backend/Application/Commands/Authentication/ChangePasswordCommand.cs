using Domain.Exceptions;
using Domain.ValueObjects;
using FluentValidation;
using Infrastructure.Repositorys.interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Authentication
{
    public record ChangePasswordCommand(Guid UserId, string CurrentPassword, string NewPassword) : IRequest;

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ChangePasswordCommandHandler> _logger;
        private readonly IValidator<ChangePasswordCommand> _validator;

        public ChangePasswordCommandHandler(
            IUserRepository userRepository,
            ILogger<ChangePasswordCommandHandler> logger,
            IValidator<ChangePasswordCommand> validator)
        {
            _userRepository = userRepository;
            _logger = logger;
            _validator = validator;
        }

        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Initiating password change process for user: {UserId}", request.UserId);

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Validation failed for password change: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                _logger.LogWarning("Password change failed: User not found for ID: {UserId}", request.UserId);
                throw new KeyNotFoundException("User not found.");
            }

            if (!user.PasswordHash.Verify(request.CurrentPassword))
            {
                _logger.LogWarning("Password change failed: Incorrect current password for user: {UserId}", request.UserId);
                throw new InvalidCredentialsException("Current password is incorrect.");
            }

            user.ChangePassword(new PasswordHash(request.NewPassword));
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Password changed successfully for user: {UserId}", request.UserId);
        }
    }
}
