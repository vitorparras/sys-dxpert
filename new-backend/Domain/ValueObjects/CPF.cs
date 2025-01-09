namespace Domain.ValueObjects
{
    public class CPF
    {
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
