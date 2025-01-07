namespace Application.DTOs.Shared
{
    public class ErrorResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string TraceId { get; set; }

        public ErrorResponse(string status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
