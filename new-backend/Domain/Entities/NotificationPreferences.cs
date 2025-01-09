using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("NotificationPreferences")]
    public class NotificationPreferences
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        [Required]
        public bool EmailNotificationsEnabled { get; private set; }

        [Required]
        public bool SmsNotificationsEnabled { get; private set; }

        [Required]
        public bool PushNotificationsEnabled { get; private set; }

        [ForeignKey("UserId")]
        public virtual User User { get; private set; }

        private NotificationPreferences() { }

        public NotificationPreferences(User user, bool emailEnabled, bool smsEnabled, bool pushEnabled)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            EmailNotificationsEnabled = emailEnabled;
            SmsNotificationsEnabled = smsEnabled;
            PushNotificationsEnabled = pushEnabled;
        }

        public void UpdatePreferences(bool emailEnabled, bool smsEnabled, bool pushEnabled)
        {
            EmailNotificationsEnabled = emailEnabled;
            SmsNotificationsEnabled = smsEnabled;
            PushNotificationsEnabled = pushEnabled;
        }
    }
}
