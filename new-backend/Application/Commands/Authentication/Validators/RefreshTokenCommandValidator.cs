using FluentValidation;

namespace Application.Commands.Authentication.Validators
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("The refresh token is required.")
                .MinimumLength(20).WithMessage("The refresh token must be valid.");
        }
    }
}
