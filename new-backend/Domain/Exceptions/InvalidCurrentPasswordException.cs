namespace Domain.Exceptions
{
    public class InvalidCurrentPasswordException : Exception
    {
        public InvalidCurrentPasswordException() { }
        public InvalidCurrentPasswordException(string message) : base(message) { }
        public InvalidCurrentPasswordException(string message, Exception innerException) : base(message, innerException) { }
    }
}
