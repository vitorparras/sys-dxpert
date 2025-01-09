using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class UserMetricsValidator : AbstractValidator<UserMetrics>
    {
        public UserMetricsValidator()
        {
            RuleFor(m => m.TotalLogins)
                .GreaterThanOrEqualTo(0).WithMessage("Total Logins must be a positive number.");

            RuleFor(m => m.AccountAgeInDays)
                .GreaterThanOrEqualTo(0).WithMessage("Account age must be a positive value.");

            RuleFor(m => m.LastLoginDate)
                .LessThanOrEqualTo(DateTime.UtcNow).When(m => m.LastLoginDate != null)
                .WithMessage("Last login date cannot be in the future.");
        }
    }
}
