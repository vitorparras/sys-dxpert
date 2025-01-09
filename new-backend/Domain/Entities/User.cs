using Domain.Entities.Enums;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100)]
        public Email Email { get; private set; }

        [Required(ErrorMessage = "CPF is required.")]
        public CPF CPF { get; private set; }

        [Required(ErrorMessage = "Password hash is required.")]
        public PasswordHash PasswordHash { get; private set; }

        [Required(ErrorMessage = "Role is required.")]
        [EnumDataType(typeof(Role))]
        public Role Role { get; private set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(11, ErrorMessage = "Phone number must be 10 or 11 digits.")]
        public PhoneNumber PhoneNumber { get; private set; }

        [Required(ErrorMessage = "Identification Code is required.")]
        [MaxLength(50, ErrorMessage = "Identification code must be less than 50 characters.")]
        public string IdentificationCode { get; private set; }

        [Required(ErrorMessage = "Department is required.")]
        [MaxLength(100, ErrorMessage = "Department must be less than 100 characters.")]
        public string Department { get; private set; }

        [Required]
        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        [Required]
        public NotificationPreferences NotificationPreferences { get; private set; }


        //   public List<LoginHistory> LoginHistory { get; private set; } = new();

        public List<RefreshToken> RefreshTokens { get; private set; } = new();

        // Constructor for EF Core (Protected for ORM use)
        protected User() { }

        public User(
            string name,
            Email email,
            PasswordHash passwordHash,
            CPF cpf,
            PhoneNumber phoneNumber,
            string identificationCode,
            string department,
            Role role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CPF = cpf;
            PhoneNumber = phoneNumber;
            IdentificationCode = identificationCode;
            Department = department;
            Role = role;
            CreatedAt = DateTime.UtcNow;
            NotificationPreferences = new NotificationPreferences();
        }

        public void UpdateUserInfo(string name, Email email, PhoneNumber phoneNumber, string department)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Department = department;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePassword(PasswordHash newPassword)
        {
            PasswordHash = newPassword;
            UpdatedAt = DateTime.UtcNow;
        }


        /// <summary>
        /// Updates the notification preferences for the user.
        /// </summary>
        /// <param name="newPreferences">New notification preferences object.</param>
        public void UpdateNotificationPreferences(NotificationPreferences newPreferences)
        {
            if (newPreferences == null)
            {
                throw new ArgumentNullException(nameof(newPreferences), "Notification preferences cannot be null.");
            }

            if (!NotificationPreferences.Equals(newPreferences))
            {
                NotificationPreferences = newPreferences;
            }

            UpdatedAt = DateTime.UtcNow;
        }

        public bool ValidatePassword(string password)
        {
            return PasswordHash.Verify(password);
        }
    }
}
