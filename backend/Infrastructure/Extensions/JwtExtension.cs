using Microsoft.AspNetCore.Http;

namespace Infrastructure.Extensions
{
    public static class JwtExtension
    {
        public static string GetJwtFromHeader(this HttpRequest request)
        {
            if (!request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                throw new ArgumentException("Token não encontrado no cabeçalho 'Authorization'.");
            }

            return authorizationHeader.ToString();
        }
    }
}
