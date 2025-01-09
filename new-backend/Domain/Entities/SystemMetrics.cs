using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("SystemMetrics")]
    public class SystemMetrics
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "CPU Usage is required.")]
        [Range(0, 100, ErrorMessage = "CPU Usage must be between 0 and 100.")]
        public double CpuUsage { get; private set; }

        [Required(ErrorMessage = "Total Memory is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Memory must be a positive value.")]
        public double TotalMemory { get; private set; }

        [Required(ErrorMessage = "Uptime is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Uptime must be a positive value.")]
        public double UptimeInMinutes { get; private set; }

        [Required]
        public DateTime CollectedAt { get; private set; }

        private SystemMetrics() { }

        public SystemMetrics(double cpuUsage, double totalMemory, double uptimeInMinutes)
        {
            Id = Guid.NewGuid();
            CpuUsage = cpuUsage;
            TotalMemory = totalMemory;
            UptimeInMinutes = uptimeInMinutes;
            CollectedAt = DateTime.UtcNow;
        }
    }
}
