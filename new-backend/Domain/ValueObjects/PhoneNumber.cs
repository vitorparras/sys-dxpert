namespace Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Number { get; private set; }
        private PhoneNumber() { }
        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || number.Length != 10 && number.Length != 11)
                throw new ArgumentException("Phone number must be 10 or 11 digits.");
            Number = number;
        }

        public override string ToString() => Number;
    }
}
