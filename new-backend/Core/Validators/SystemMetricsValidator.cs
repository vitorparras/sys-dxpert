using Core.Entities;
using FluentValidation;

namespace Core.Validators
{
    public class SystemMetricsValidator : AbstractValidator<SystemMetrics>
    {
        public SystemMetricsValidator()
        {
            RuleFor(m => m.CpuUsage)
                .InclusiveBetween(0, 100).WithMessage("CPU Usage must be between 0 and 100.");

            RuleFor(m => m.TotalMemory)
                .GreaterThan(0).WithMessage("Total Memory must be a positive number.");

            RuleFor(m => m.UptimeInMinutes)
                .GreaterThan(0).WithMessage("Uptime must be a positive value.");

            RuleFor(m => m.CollectedAt)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Collected date cannot be in the future.");
        }
    }
}
