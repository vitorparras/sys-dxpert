using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IConfiguration configuration, ILogger<AuthService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GetSigningKey();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email.Value),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(GetTokenExpiration()),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Guid? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GetSigningKey();

            try
            {
                tokenHandler.ValidateToken(token, GetValidationParameters(key), out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                return userIdClaim != null ? Guid.Parse(userIdClaim) : null;
            }
            catch (SecurityTokenException ex)
            {
                _logger.LogWarning("Invalid token: {Message}", ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while validating the token.");
                return null;
            }
        }

        public RefreshToken GenerateRefreshToken(User user)
        {
            return new RefreshToken(user, DateTime.UtcNow.AddDays(7));
        }

        public bool ValidatePassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private SecurityKey GetSigningKey()
        {
            var secret = _configuration["Jwt:Secret"];
            if (string.IsNullOrWhiteSpace(secret))
                throw new InvalidOperationException("JWT Secret is not configured.");

            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
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
                throw new InvalidOperationException("JWT Expiration time is not configured or invalid.");
            return minutes;
        }
    }
}
