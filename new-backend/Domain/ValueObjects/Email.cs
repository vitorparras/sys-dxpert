using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects
{
    [Owned]
    public class Email
    {
        [Required]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Value { get; private set; }

        private Email() { }

        public Email(string value)
        {
            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email format.");

            Value = value;
        }

        public static bool IsValidEmail(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Contains("@") &&
                   value.Contains(".");
        }

        public override string ToString() => Value;
    }
}
