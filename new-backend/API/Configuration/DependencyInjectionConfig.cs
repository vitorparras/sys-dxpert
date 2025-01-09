using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using FluentValidation;
using Infrastructure.ExternalServices;
using Infrastructure.ExternalServices.Interfaces;
using Infrastructure.Repositorys;
using Infrastructure.Repositorys.interfaces;


namespace API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            RegisterRepositories(services);

            RegisterServices(services);

            RegisterAutoMapper(services);

            RegisterFluentValidation(services);

            RegisterMediatR(services);

            return services;
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailService, EmailService>();
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

        private static void RegisterFluentValidation(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void RegisterMediatR(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}
