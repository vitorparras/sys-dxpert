using Application.DTOs.Shared;
using Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode, errorResponse) = MapExceptionToResponse(exception);

            _logger.LogError(exception, "An exception occurred while processing the request");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return context.Response.WriteAsync(response);
        }

        private (int, ErrorResponse) MapExceptionToResponse(Exception exception)
        {
            return exception switch
            {
                DomainException domainException => ((int)HttpStatusCode.BadRequest,
                    new ErrorResponse("Bad Request", domainException.Message)),
                NotFoundException notFoundException => ((int)HttpStatusCode.NotFound,
                    new ErrorResponse("Not Found", notFoundException.Message)),
                UnauthorizedAccessException => ((int)HttpStatusCode.Unauthorized,
                    new ErrorResponse("Unauthorized", "Unauthorized access")),
                _ => ((int)HttpStatusCode.InternalServerError,
                    new ErrorResponse("Internal Server Error",
                        _env.IsDevelopment() ? exception.ToString() : "An error occurred processing your request."))
            };
        }
    }
}
