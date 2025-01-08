using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateToken(User user)
        {
            var key = GetSigningKey();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.Value),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(GetTokenExpiration()),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }

        public Guid? ValidateToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            var key = GetSigningKey();
            try
            {
                _tokenHandler.ValidateToken(token, GetValidationParameters(key), out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                return userIdClaim != null ? Guid.Parse(userIdClaim) : null;
            }
            catch
            {
                return null;
            }
        }

        public RefreshToken GenerateRefreshToken(User user)
        {
            return new RefreshToken(user, DateTime.UtcNow.AddDays(7));
        }

        private SecurityKey GetSigningKey()
        {
            var secret = _configuration["Jwt:Secret"];
            if (string.IsNullOrWhiteSpace(secret))
                throw new InvalidOperationException("JWT Secret is not properly configured.");

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }

        private TokenValidationParameters GetValidationParameters(SecurityKey signingKey)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        }

        private double GetTokenExpiration()
        {
            var expiration = _configuration["Jwt:ExpirationInMinutes"];
            if (!double.TryParse(expiration, out var minutes))
                throw new InvalidOperationException("JWT expiration time is misconfigured.");
            return minutes;
        }
    }
}
