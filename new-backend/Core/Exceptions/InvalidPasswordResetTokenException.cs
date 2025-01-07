namespace Core.Exceptions
{
    public class InvalidPasswordResetTokenException : Exception
    {
        public InvalidPasswordResetTokenException() { }
        public InvalidPasswordResetTokenException(string message) : base(message) { }
        public InvalidPasswordResetTokenException(string message, Exception innerException) : base(message, innerException) { }
    }
}
