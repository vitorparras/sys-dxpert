using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SysDbContext _context;
        private readonly ILogger<TokenService> _logger;

        public TokenService(IConfiguration configuration, SysDbContext context, ILogger<TokenService> logger)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }

        public TokenResponse GenerateToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];
            var jwtExpirationMinutes = int.Parse(_configuration["Jwt:ExpirationMinutes"]);

            if (string.IsNullOrWhiteSpace(jwtKey))
                throw new InvalidOperationException("JWT key is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email.Value),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtExpirationMinutes),
                signingCredentials: credentials
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = new RefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow.AddDays(7));

            _logger.LogInformation("Generated JWT and Refresh Token for user {UserId}", user.Id);

            return new TokenResponse(jwtToken, refreshToken);
        }

        public async Task PersistRefreshTokenAsync(RefreshToken refreshToken, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) throw new InvalidOperationException("User not found.");

            user.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Refresh token persisted for user {UserId}", userId);
        }

        public async Task<bool> ValidateRefreshTokenAsync(Guid userId, string refreshToken)
        {
            var user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                _logger.LogWarning("User not found during refresh token validation.");
                return false;
            }

            var storedToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == refreshToken);
            if (storedToken == null || storedToken.IsExpired)
            {
                _logger.LogWarning("Invalid or expired refresh token for user {UserId}", userId);
                return false;
            }

            _logger.LogInformation("Refresh token successfully validated for user {UserId}", userId);
            return true;
        }

        public bool ValidateToken(string token)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    ClockSkew = TimeSpan.Zero
                }, out _);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogWarning("JWT Token validation failed: {Message}", ex.Message);
                return false;
            }
        }
    }
}
