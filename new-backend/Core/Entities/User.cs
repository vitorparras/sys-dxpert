using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Enums;
using Core.ValueObjects;

namespace Core.Entities
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100)]
        public Email Email { get; private set; }

        [Required(ErrorMessage = "Password hash is required.")]
        public PasswordHash PasswordHash { get; private set; }

        [Required(ErrorMessage = "Role is required.")]
        [EnumDataType(typeof(Role))]
        public Role Role { get; private set; }

        [Required]
        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        [Required]
        public NotificationPreferences NotificationPreferences { get; private set; }

        public List<LoginHistory> LoginHistory { get; private set; } = new();

        public List<RefreshToken> RefreshTokens { get; private set; } = new();

        // Construtor para EF Core
        private User() { }

        public User(string name, Email email, PasswordHash passwordHash, Role role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            CreatedAt = DateTime.UtcNow;
            NotificationPreferences = new NotificationPreferences(true, true, true);
        }

        public void Update(string name, Email email)
        {
            Name = name;
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePassword(PasswordHash newPassword)
        {
            PasswordHash = newPassword;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateNotificationPreferences(bool emailEnabled, bool smsEnabled, bool pushEnabled)
        {
            NotificationPreferences.UpdatePreferences(emailEnabled, smsEnabled, pushEnabled);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
