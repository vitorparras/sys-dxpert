using Infrastructure.Extensions;
using Service.Interfaces;

namespace API.Middlewares
{
    public class JwtTokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public JwtTokenValidationMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.EndsWith("/Login", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            var token = context.Request.GetJwtFromHeader();

            using var scope = _serviceScopeFactory.CreateScope();

            var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();

            var valid = await authService.TokenIsValid(token);

            if (!valid.Success || string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized : " + valid.Message);
            }

            await _next(context);
        }
    }
}
