using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; private set; }
        public string Token { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        private RefreshToken() { } // For EF Core

        public RefreshToken(User user, DateTime expiresAt)
        {
            Id = Guid.NewGuid();
            Token = Guid.NewGuid().ToString();
            ExpiresAt = expiresAt;
            UserId = user.Id;
            User = user;
        }

        public bool IsExpired() => DateTime.UtcNow >= ExpiresAt;
    }
}
