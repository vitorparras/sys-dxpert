using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("The database connection string is not configured. Please check your application settings.");
            }

            services.AddDbContext<SysDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
