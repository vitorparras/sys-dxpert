using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Login
{
    public interface IRequestPasswordResetUseCase
    {
        Task ExecuteAsync(string email);
    }

    public class RequestPasswordResetUseCase : IRequestPasswordResetUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<RequestPasswordResetUseCase> _logger;

        public RequestPasswordResetUseCase(
            IUserRepository userRepository,
            IEmailService emailService,
            ITokenService tokenService,
            ILogger<RequestPasswordResetUseCase> logger)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task ExecuteAsync(string email)
        {
            _logger.LogInformation("Password reset request initiated for email: {Email}", email);

            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning("Password reset requested for non-existent email: {Email}", email);
                return;
            }

            _logger.LogInformation("User found for email: {Email}. Generating password reset token.", email);

            var resetToken = _tokenService.GeneratePasswordResetToken();
            user.SetPasswordResetToken(resetToken.Token, resetToken.Expiration);

            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Password reset token generated and saved for UserId: {UserId}", user.Id);

            await _emailService.SendPasswordResetEmailAsync(user.Email.Value, resetToken.Token);

            _logger.LogInformation("Password reset email sent to: {Email}", email);
        }
    }
}
