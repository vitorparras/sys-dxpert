using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class LoginHistoryValidator : AbstractValidator<LoginHistory>
    {
        public LoginHistoryValidator()
        {
            RuleFor(l => l.LoginDate)
                .NotEmpty().WithMessage("Login date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Login date cannot be in the future.");

            RuleFor(l => l.IsSuccessful)
                .NotNull().WithMessage("Success status is required.");

            RuleFor(l => l.IpAddress)
                .MaximumLength(45).WithMessage("IP address must be at most 45 characters.")
                .Matches(@"^(?:\d{1,3}\.){3}\d{1,3}$").When(l => !string.IsNullOrEmpty(l.IpAddress))
                .WithMessage("Invalid IP address format.");
        }
    }
}
