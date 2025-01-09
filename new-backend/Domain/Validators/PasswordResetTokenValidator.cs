using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class PasswordResetTokenValidator : AbstractValidator<PasswordResetToken>
    {
        public PasswordResetTokenValidator()
        {
            RuleFor(p => p.Token)
                .NotEmpty().WithMessage("Token is required.")
                .MaximumLength(512).WithMessage("Token length cannot exceed 512 characters.");

            RuleFor(p => p.ExpiresAt)
                .GreaterThan(DateTime.UtcNow).WithMessage("Expiration date must be in the future.");

            RuleFor(p => p.IsUsed)
                .Equal(false).WithMessage("Token must not be already used.");
        }
    }
}
