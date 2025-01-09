using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class NotificationPreferencesValidator : AbstractValidator<NotificationPreferences>
    {
        public NotificationPreferencesValidator()
        {
            RuleFor(p => p.EmailNotificationsEnabled)
                .NotNull().WithMessage("Email notification preference must be specified.");

            RuleFor(p => p.SmsNotificationsEnabled)
                .NotNull().WithMessage("SMS notification preference must be specified.");

            RuleFor(p => p.PushNotificationsEnabled)
                .NotNull().WithMessage("Push notification preference must be specified.");
        }
    }
}
