using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("LoginHistory")]
    public class LoginHistory
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        [Required(ErrorMessage = "Login date is required.")]
        public DateTime LoginDate { get; private set; }

        [MaxLength(45)]
        public string? IpAddress { get; private set; }

        [Required(ErrorMessage = "Success status is required.")]
        public bool IsSuccessful { get; private set; }

        [ForeignKey("UserId")]
        public virtual User User { get; private set; }

        private LoginHistory() { }

        public LoginHistory(User user, DateTime loginDate, bool isSuccessful, string? ipAddress = null)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            LoginDate = loginDate;
            IsSuccessful = isSuccessful;
            IpAddress = ipAddress;
        }
    }
}
