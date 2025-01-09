namespace Domain.ValueObjects
{
    public class RefreshToken
    {
        public string Token { get; private set; }

        public DateTime ExpiresAt { get; private set; }

        public bool Revoked { get; private set; }

        public RefreshToken(string token, DateTime expiresAt)
        {
            Token = token;
            ExpiresAt = expiresAt;
        }

        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    }
}
