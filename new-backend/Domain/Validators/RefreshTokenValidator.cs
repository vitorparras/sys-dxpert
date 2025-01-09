using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validators
{
    public class RefreshTokenValidator : AbstractValidator<RefreshToken>
    {
        public RefreshTokenValidator()
        {
            RuleFor(token => token.Token)
                .NotEmpty().WithMessage("Token cannot be empty.")
                .MaximumLength(512).WithMessage("Token length cannot exceed 512 characters.");

            RuleFor(token => token.ExpiresAt)
                .GreaterThan(DateTime.UtcNow).WithMessage("Expiration date must be in the future.");

            RuleFor(token => token.Revoked)
                .NotEqual(true).WithMessage("Token has already been revoked.");
        }
    }
}
