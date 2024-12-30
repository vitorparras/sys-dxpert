using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Helpers
{
    public static class DatabaseMigrationHelper
    {
        public static void ApplyMigrations(IServiceProvider services)
        {
            try
            {
                using var scope = services.CreateScope();
                var scopedServices = scope.ServiceProvider;

                var context = scopedServices.GetRequiredService<SysDbContext>();
                var logger = scopedServices.GetRequiredService<ILogger<DatabaseMigrationHelper>>();

                context.Database.Migrate();
                logger.LogInformation("Database migrated successfully.");
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<DatabaseMigrationHelper>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
                throw; // Opcional: Re-lançar exceções para gerenciamento em níveis superiores
            }
        }
    }
}
