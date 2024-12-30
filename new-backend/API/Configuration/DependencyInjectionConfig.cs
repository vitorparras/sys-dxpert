using Core.Interfaces;
using Core.Services;
using Infrastructure.ExternalServices;
using Infrastructure.Persistence.Repositorys;

namespace API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            // Services
            services.AddScoped<IAuthService, JwtAuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
