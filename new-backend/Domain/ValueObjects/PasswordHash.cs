namespace Domain.ValueObjects
{
    public class PasswordHash
    {
        public string Hash { get; private set; }

        public PasswordHash(string plainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(plainTextPassword))
                throw new ArgumentException("Password cannot be empty.");

            Hash = BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        public bool Verify(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, Hash);
        }

        public override string ToString() => Hash;
    }
}
