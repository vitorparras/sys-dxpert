using FluentValidation;
using Infrastructure.ExternalServices.Interfaces;
using Infrastructure.Repositorys.interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Authentication
{
    public record RequestPasswordResetCommand(string Email) : IRequest;

    public class RequestPasswordResetCommandHandler : IRequestHandler<RequestPasswordResetCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<RequestPasswordResetCommandHandler> _logger;
        private readonly IValidator<RequestPasswordResetCommand> _validator;

        public RequestPasswordResetCommandHandler(
            IUserRepository userRepository,
            IEmailService emailService,
            ILogger<RequestPasswordResetCommandHandler> logger,
            IValidator<RequestPasswordResetCommand> validator)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _logger = logger;
            _validator = validator;
        }

        public async Task Handle(RequestPasswordResetCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Initiating password reset request for email: {Email}", request.Email);

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Validation failed for password reset request: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                _logger.LogWarning("Password reset request failed: User not found for email {Email}", request.Email);
                throw new KeyNotFoundException("User with the provided email not found.");
            }

            var resetToken = Guid.NewGuid().ToString();
            var resetLink = $"https://yourapp.com/reset-password?token={resetToken}";

            await _emailService.SendEmailAsync(request.Email, "Password Reset Request",
                $"Click the link to reset your password: {resetLink}");

            _logger.LogInformation("Password reset link sent successfully to {Email}", request.Email);
        }
    }
}
