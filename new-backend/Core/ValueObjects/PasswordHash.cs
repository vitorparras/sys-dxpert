﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValueObjects
{
    public class PasswordHash
    {
        public string Value { get; }

        private PasswordHash(string value)
        {
            Value = value;
        }

        public static PasswordHash Create(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentNullException(nameof(passwordHash));

            return new PasswordHash(passwordHash);
        }
    }
}
