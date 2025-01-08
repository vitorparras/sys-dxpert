namespace Core.Interfaces
{
    public interface IUserMetricsService
    {
        Task<UserMetrics> CalculateMetricsAsync(Guid userId);
    }
}
