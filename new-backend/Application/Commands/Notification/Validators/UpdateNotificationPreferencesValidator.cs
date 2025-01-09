using FluentValidation;
using Application.DTOs;

namespace Application.Validators
{
    public class UpdateNotificationPreferencesValidator : AbstractValidator<UpdateNotificationPreferencesDto>
    {
        public UpdateNotificationPreferencesValidator()
        {
            RuleFor(x => x.EmailNotification).NotNull().WithMessage("Email notification preference is required.");
            RuleFor(x => x.SmsNotification).NotNull().WithMessage("SMS notification preference is required.");
            RuleFor(x => x.WhatsappNotification).NotNull().WithMessage("Whatsapp notification preference is required.");
            RuleFor(x => x.MonthlyReport).NotNull().WithMessage("Monthly report preference is required.");
            RuleFor(x => x.RenewalReminders).NotNull().WithMessage("Renewal reminder preference is required.");
            RuleFor(x => x.NewPolicyAlerts).NotNull().WithMessage("New policy alerts preference is required.");
        }
    }
}
