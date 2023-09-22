namespace N43_HT1.Services.Interfaces;

public interface IEmployeeService
{
    Task CreatePerformanceRecordAsync(Guid id);
}