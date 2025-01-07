using Core.Interfaces;
using System.Security.Cryptography;

namespace Application.UseCases.Login
{
    public class RequestPasswordResetUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public RequestPasswordResetUseCase(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task ExecuteAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                // Don't reveal that the user doesn't exist
                return;
            }

            var resetToken = GenerateResetToken();
            user.SetPasswordResetToken(resetToken, DateTime.UtcNow.AddHours(1));
            await _userRepository.UpdateAsync(user);

            await _emailService.SendPasswordResetEmailAsync(user.Email.Value, resetToken);
        }

        private string GenerateResetToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}

