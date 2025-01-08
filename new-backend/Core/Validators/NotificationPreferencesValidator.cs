using Core.Entities;
using FluentValidation;

namespace Core.Validators
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
