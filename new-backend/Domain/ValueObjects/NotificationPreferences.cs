using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects
{
    [Owned]
    public class NotificationPreferences
    {
        [Required] public bool SmsNotification { get; }
        [Required] public bool MonthlyReport { get; }
        [Required] public bool RenewalReminders { get; }
        [Required] public bool NewPolicyAlerts { get; }
        [Required] public bool WhatsappNotification { get; }
        [Required] public bool EmailNotification { get; }

        public NotificationPreferences() {
            SmsNotification = true;
            MonthlyReport = true;
            RenewalReminders = true;
            NewPolicyAlerts = true;
            WhatsappNotification = true;
            EmailNotification = true;
        }

        public NotificationPreferences(
            bool smsNotification, bool monthlyReport, bool renewalReminders,
            bool newPolicyAlerts, bool whatsappNotification, bool emailNotification)
        {
            SmsNotification = smsNotification;
            MonthlyReport = monthlyReport;
            RenewalReminders = renewalReminders;
            NewPolicyAlerts = newPolicyAlerts;
            WhatsappNotification = whatsappNotification;
            EmailNotification = emailNotification;
        }

        // Método de atualização que cria um novo objeto (imutável)
        public NotificationPreferences Update(bool smsNotification, bool monthlyReport, bool renewalReminders,
            bool newPolicyAlerts, bool whatsappNotification, bool emailNotification)
        {
            return new NotificationPreferences(smsNotification, monthlyReport, renewalReminders,
                newPolicyAlerts, whatsappNotification, emailNotification);
        }

        // Equals e GetHashCode para comparação de VO
        public override bool Equals(object? obj)
        {
            if (obj is not NotificationPreferences other) return false;
            return SmsNotification == other.SmsNotification &&
                   MonthlyReport == other.MonthlyReport &&
                   RenewalReminders == other.RenewalReminders &&
                   NewPolicyAlerts == other.NewPolicyAlerts &&
                   WhatsappNotification == other.WhatsappNotification &&
                   EmailNotification == other.EmailNotification;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SmsNotification, MonthlyReport, RenewalReminders,
                                    NewPolicyAlerts, WhatsappNotification, EmailNotification);
        }
    }
}
