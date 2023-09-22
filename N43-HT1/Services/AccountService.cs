using System.Diagnostics.CodeAnalysis;
using N43_HT1.Services.Interfaces;

namespace N43_HT1.Services;

public class AccountService : IAccountService
{
    private readonly IEmployeeService _employeeService;
    private readonly IPerformanceService _performanceService;

    public AccountService(IEmployeeService employeeService, IPerformanceService performanceService)
    {
        _employeeService = employeeService;
        _performanceService = performanceService;
    }

    public Task CreateReportAsync(Guid id)
    {
        var result = _employeeService.CreatePerformanceRecordAsync(id)
        .ContinueWith(_ => _performanceService.ReportPerformanceAsync(id));

        return result;
    }
}