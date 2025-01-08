namespace Core.Interfaces
{
    public interface ISystemMetricsService
    {
        Task<SystemMetrics> GetSystemMetricsAsync();
    }
}
