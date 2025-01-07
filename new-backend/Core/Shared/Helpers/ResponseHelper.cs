using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core.Shared.Helpers
{
    public static class ResponseHelper
    {
        public static IActionResult CreateResponse(string message, HttpStatusCode statusCode, object? data = null)
        {
            var response = new
            {
                success = (int)statusCode < 400,
                message,
                data
            };

            return statusCode switch
            {
                HttpStatusCode.OK => new OkObjectResult(response),
                HttpStatusCode.Created => new CreatedResult(string.Empty, response),
                HttpStatusCode.NoContent => new NoContentResult(),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
                HttpStatusCode.NotFound => new NotFoundObjectResult(response),
                _ => new ObjectResult(response) { StatusCode = (int)statusCode }
            };
        }
    }

}