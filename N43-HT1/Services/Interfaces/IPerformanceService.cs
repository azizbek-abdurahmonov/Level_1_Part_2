namespace N43_HT1.Services.Interfaces;

public interface IPerformanceService
{
    Task<bool> ReportPerformanceAsync(Guid id);
}