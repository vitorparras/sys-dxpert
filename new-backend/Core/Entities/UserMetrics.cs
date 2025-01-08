using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("UserMetrics")]
    public class UserMetrics
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        [Required(ErrorMessage = "Total Logins is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Total Logins must be a positive number.")]
        public int TotalLogins { get; private set; }

        public DateTime? LastLoginDate { get; private set; }

        [Required(ErrorMessage = "Account Age is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Account Age must be a positive value.")]
        public int AccountAgeInDays { get; private set; }

        [ForeignKey("UserId")]
        public virtual User User { get; private set; }

        private UserMetrics() { }

        public UserMetrics(User user, int totalLogins, DateTime? lastLoginDate, int accountAgeInDays)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            TotalLogins = totalLogins;
            LastLoginDate = lastLoginDate;
            AccountAgeInDays = accountAgeInDays;
        }

        public void UpdateLoginMetrics(int totalLogins, DateTime lastLoginDate)
        {
            TotalLogins = totalLogins;
            LastLoginDate = lastLoginDate;
        }

        public void UpdateAccountAge(int accountAgeInDays)
        {
            AccountAgeInDays = accountAgeInDays;
        }
    }
}
