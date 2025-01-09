using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects
{
    [Owned]
    public class CPF
    {
        [Required]
        [MaxLength(11)]
        public string Value { get; private set; }

        private CPF() { }

        public CPF(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 11)
                throw new ArgumentException("CPF must have exactly 11 digits.");
            Value = value;
        }

        public override string ToString() => Value;
    }
}
