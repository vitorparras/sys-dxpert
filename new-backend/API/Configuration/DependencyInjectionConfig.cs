using Application.Mappers;
using Core.Interfaces;
using Core.Services;
using Infrastructure.ExternalServices;
using Infrastructure.Persistence.Repositorys;
using Infrastructure.Persistence.Repositorys.interfaces;

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
            services.AddScoped<INotificationPreferencesRepository, NotificationPreferencesRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<ISystemMetricsRepository, SystemMetricsRepository>();
            services.AddScoped<IUserMetricsRepository, UserMetricsRepository>();
            services.AddScoped<ILoginHistoryRepository, LoginHistoryRepository>();
            services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<INotificationPreferencesService, NotificationPreferencesService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<ISystemMetricsService, SystemMetricsService>();
            services.AddScoped<IUserMetricsService, UserMetricsService>();
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
