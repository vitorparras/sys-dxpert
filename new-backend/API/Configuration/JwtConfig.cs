using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Configuration
{
    public static class JwtConfig
    {
        /// <summary>
        /// Configures JWT authentication using direct configuration from appsettings.json.
        /// </summary>
        public static IServiceCollection ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration["Jwt:Secret"];
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];

            if (string.IsNullOrWhiteSpace(secretKey))
            {
                throw new InvalidOperationException("JWT Secret key is not configured properly in appsettings.json.");
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = !string.IsNullOrWhiteSpace(issuer),
                    ValidIssuer = issuer,
                    ValidateAudience = !string.IsNullOrWhiteSpace(audience),
                    ValidAudience = audience,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };
            });

            return services;
        }
    }
}
