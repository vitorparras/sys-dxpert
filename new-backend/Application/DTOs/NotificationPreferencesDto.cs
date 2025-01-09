namespace Application.DTOs
{
    public class NotificationPreferencesDto
    {
        public bool SmsNotification { get; set; }
        public bool MonthlyReport { get; set; }
        public bool RenewalReminders { get; set; }
        public bool NewPolicyAlerts { get; set; }
        public bool WhatsappNotification { get; set; }
        public bool EmailNotification { get; set; }
    }
}
