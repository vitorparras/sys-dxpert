using Domain.Exceptions;
using Domain.ValueObjects;
using FluentValidation;
using Infrastructure.Repositorys.interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Authentication
{
    public record ResetPasswordCommand(string Token, string NewPassword) : IRequest;

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ResetPasswordCommandHandler> _logger;
        private readonly IValidator<ResetPasswordCommand> _validator;

        public ResetPasswordCommandHandler(
            IUserRepository userRepository,
            ILogger<ResetPasswordCommandHandler> logger,
            IValidator<ResetPasswordCommand> validator)
        {
            _userRepository = userRepository;
            _logger = logger;
            _validator = validator;
        }

        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Initiating password reset process for token: {Token}", request.Token);

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Validation failed for password reset: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _userRepository.GetByRefreshTokenAsync(request.Token);
            if (user == null)
            {
                _logger.LogWarning("Invalid token provided during password reset attempt.");
                throw new InvalidCredentialsException("Invalid or expired token.");
            }

            user.ChangePassword(new PasswordHash(request.NewPassword));
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Password successfully reset for user {UserId}", user.Id);
        }
    }
}
