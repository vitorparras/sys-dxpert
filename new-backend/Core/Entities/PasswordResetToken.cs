using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("PasswordResetTokens")]
    public class PasswordResetToken
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        [Required]
        [MaxLength(512)]
        public string Token { get; private set; }

        [Required]
        public DateTime ExpiresAt { get; private set; }

        [Required]
        public bool IsUsed { get; private set; }

        [ForeignKey("UserId")]
        public virtual User User { get; private set; }

        private PasswordResetToken() { }

        public PasswordResetToken(User user, DateTime expiresAt)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            Token = Guid.NewGuid().ToString();
            ExpiresAt = expiresAt;
            IsUsed = false;
        }

        public bool IsExpired() => DateTime.UtcNow >= ExpiresAt;

        public void MarkAsUsed()
        {
            if (IsExpired())
                throw new InvalidOperationException("Cannot use an expired token.");

            IsUsed = true;
        }
    }
}
