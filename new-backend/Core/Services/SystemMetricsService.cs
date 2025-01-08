using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Core.Services
{
    public class SystemMetricsService : ISystemMetricsService
    {
        private readonly ILogger<SystemMetricsService> _logger;

        public SystemMetricsService(ILogger<SystemMetricsService> logger)
        {
            _logger = logger;
        }

        public Task<SystemMetrics> GetSystemMetricsAsync()
        {
            _logger.LogInformation("Collecting system metrics...");

            var metrics = new SystemMetrics
            {
                CpuUsage = GetCpuUsage(),
                TotalMemory = GetTotalMemoryUsage(),
                UptimeInMinutes = GetSystemUptime()
            };

            _logger.LogInformation("System metrics collected successfully.");
            return Task.FromResult(metrics);
        }

        private double GetCpuUsage()
        {
            try
            {
                using var process = Process.GetCurrentProcess();
                var cpuUsage = process.TotalProcessorTime.TotalMilliseconds /
                               (Environment.ProcessorCount *
                                (DateTime.UtcNow - process.StartTime.ToUniversalTime()).TotalMilliseconds) * 100;

                _logger.LogDebug("CPU Usage calculated: {CpuUsage:F2}%", cpuUsage);
                return Math.Round(cpuUsage, 2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calculating CPU usage.");
                throw;
            }
        }

        private double GetTotalMemoryUsage()
        {
            try
            {
                var totalMemory = GC.GetTotalMemory(false) / 1024 / 1024; // Convertendo para MB
                _logger.LogDebug("Total memory usage calculated: {TotalMemory} MB", totalMemory);
                return totalMemory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calculating memory usage.");
                throw;
            }
        }

        private double GetSystemUptime()
        {
            try
            {
                var uptime = (DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()).TotalMinutes;
                _logger.LogDebug("System uptime calculated: {UptimeInMinutes} minutes", uptime);
                return Math.Round(uptime, 2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calculating system uptime.");
                throw;
            }
        }
    }
}
