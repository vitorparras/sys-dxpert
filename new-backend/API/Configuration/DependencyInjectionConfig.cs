using Application.Mappers;
using Core.Interfaces;
using Core.Services;
using Infrastructure.ExternalServices;
using Infrastructure.Persistence.Repositorys;

namespace API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            // Register Repositories
            RegisterRepositories(services);

            // Register Services
            RegisterServices(services);

            // Register AutoMapper Profiles
            RegisterAutoMapper(services);

            return services;
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, JwtAuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            var mapperProfiles = typeof(UserMapping).Assembly.ExportedTypes
                .Where(type => typeof(AutoMapper.Profile).IsAssignableFrom(type) && !type.IsAbstract)
                .ToArray();

            if (mapperProfiles.Length == 0)
            {
                throw new InvalidOperationException("No AutoMapper profiles were found in the assembly.");
            }

            services.AddAutoMapper(mapperProfiles);
        }
    }
}
