using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

namespace API.Configuration
{
    public static class RateLimitingConfig
    {
        public static IServiceCollection ConfigureRateLimiting(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = configuration.GetValue<int>("RateLimiting:PermitLimit", 20),
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(configuration.GetValue<int>("RateLimiting:Window", 1))
                        }));
                options.RejectionStatusCode = 429;
            });

            return services;
        }
    }
}
