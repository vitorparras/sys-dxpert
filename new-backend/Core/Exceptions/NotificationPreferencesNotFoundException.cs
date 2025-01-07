namespace Core.Exceptions
{
    public class NotificationPreferencesNotFoundException : Exception
    {
        public NotificationPreferencesNotFoundException() { }
        public NotificationPreferencesNotFoundException(string message) : base(message) { }
        public NotificationPreferencesNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
