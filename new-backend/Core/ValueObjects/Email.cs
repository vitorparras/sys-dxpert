using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            email = email.Trim();

            if (email.Length > 256)
                throw new ArgumentException("Email is too long");

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                throw new ArgumentException("Email is invalid");

            return new Email(email);
        }
    }
}
