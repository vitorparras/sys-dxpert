using Application.DTOs;
using Core.Interfaces;

namespace Application.UseCases.Login
{
    public class ResetPasswordUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public ResetPasswordUseCase(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task ExecuteAsync(ResetPasswordDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !user.IsPasswordResetTokenValid(request.ResetToken))
            {
                throw new InvalidOperationException("Invalid or expired password reset token");
            }

            var newPasswordHash = _authService.HashPassword(request.NewPassword);
            user.UpdatePassword(Core.ValueObjects.PasswordHash.Create(newPasswordHash));
            user.ClearPasswordResetToken();
            await _userRepository.UpdateAsync(user);
        }
    }
}

