using Microsoft.Extensions.Configuration;
using Serilog;

namespace Infrastructure.Logging
{
    public static class SerilogConfiguration
    {
        public static void Configure(IConfiguration configuration)
        {
           /* Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/authsystem-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();*/
        }
    }
}
