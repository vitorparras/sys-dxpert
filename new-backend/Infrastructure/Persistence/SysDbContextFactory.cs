using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{

    public class SysDbContextFactory : IDesignTimeDbContextFactory<SysDbContext>
    {
        public SysDbContext CreateDbContext(string[] args)
        {
            // Determine the environment
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Could not find a connection string named 'DefaultConnection'");
            }

            // Create DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<SysDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SysDbContext(optionsBuilder.Options);
        }
    }
}

