namespace API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;

            try
            {
                _logger.LogInformation("HTTP {RequestMethod} {RequestPath} started at {StartTime}",
                    context.Request.Method,
                    context.Request.Path,
                    startTime);

                await _next(context);

                var elapsedTime = DateTime.UtcNow - startTime;

                _logger.LogInformation("HTTP {RequestMethod} {RequestPath} completed with status code {StatusCode} in {ElapsedTime}ms",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    elapsedTime.TotalMilliseconds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HTTP {RequestMethod} {RequestPath} failed with an unhandled exception",
                    context.Request.Method,
                    context.Request.Path);

                throw;
            }
        }
    }
}
