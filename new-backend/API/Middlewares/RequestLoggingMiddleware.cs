using Serilog;

namespace API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Log.Information("HTTP {RequestMethod} {RequestPath} started", context.Request.Method, context.Request.Path);

            await _next(context);

            Log.Information("HTTP {RequestMethod} {RequestPath} completed with status code {StatusCode}",
                context.Request.Method, context.Request.Path, context.Response.StatusCode);
        }
    }
}
