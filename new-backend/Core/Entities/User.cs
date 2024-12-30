using Core.Enums;
using Core.ValueObjects;

namespace Core.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public Email Email { get; private set; }
        public string Name { get; private set; }
        public string? Phone { get; private set; }
        public string CPF { get; private set; }
        public PasswordHash PasswordHash { get; private set; }
        public Role Role { get; private set; }
        public string? PasswordResetToken { get; private set; }
        public DateTime? PasswordResetTokenExpires { get; private set; }

        private User() { } // For EF Core

        public User(Email email, string name, string cpf, PasswordHash passwordHash, Role role, string? phone = null)
        {
            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            CPF = cpf;
            PasswordHash = passwordHash;
            Role = role;
            Phone = phone;
        }

        public void Update(string name, string? phone)
        {
            Name = name;
            Phone = phone;
        }

        public void UpdatePassword(PasswordHash newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }

        public void SetPasswordResetToken(string token, DateTime expires)
        {
            PasswordResetToken = token;
            PasswordResetTokenExpires = expires;
        }

        public void ClearPasswordResetToken()
        {
            PasswordResetToken = null;
            PasswordResetTokenExpires = null;
        }

        public bool IsPasswordResetTokenValid(string token)
        {
            return PasswordResetToken == token && PasswordResetTokenExpires > DateTime.UtcNow;
        }
    }
}
