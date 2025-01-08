using System.ComponentModel.DataAnnotations;

namespace Core.ValueObjects
{
    public class PasswordHash
    {
        [Required(ErrorMessage = "Password hash cannot be empty.")]
        public string Value { get; private set; }

        private PasswordHash() { }

        public PasswordHash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password hash cannot be empty.");
            Value = value;
        }

        public override string ToString() => Value;
    }
}
