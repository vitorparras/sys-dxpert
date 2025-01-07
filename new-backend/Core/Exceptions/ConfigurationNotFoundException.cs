namespace Core.Exceptions
{
    public class ConfigurationNotFoundException : Exception
    {
        public ConfigurationNotFoundException() { }
        public ConfigurationNotFoundException(string message) : base(message) { }
        public ConfigurationNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
