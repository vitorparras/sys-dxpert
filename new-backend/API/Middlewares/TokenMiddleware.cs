using Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthService _authService;

        public TokenMiddleware(RequestDelegate next, IAuthService authService)
        {
            _next = next;
            _authService = authService;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            var token = ExtractTokenFromHeader(context);

            if (!string.IsNullOrEmpty(token) && _authService.ValidateToken(token))
            {
                var userId = ExtractUserIdFromToken(token);

                if (userId.HasValue)
                {
                    context.Items["User"] = await userRepository.GetByIdAsync(userId.Value);
                }
            }

            await _next(context);
        }

        private string? ExtractTokenFromHeader(HttpContext context)
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            return authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;
        }

        private Guid? ExtractUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(userIdClaim, out var userId) ? userId : null;
        }
    }
}
