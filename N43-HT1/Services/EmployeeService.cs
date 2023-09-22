using N43_HT1.Services.Interfaces;

namespace N43_HT1.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUserService _userService;
    private Mutex _mutex = new(false, "mutex");

    public EmployeeService(IUserService userService)
    {
        _userService = userService;
    }

    public Task CreatePerformanceRecordAsync(Guid id)
    {
        return Task.Run(() =>
        {
            _mutex.WaitOne();
            var foundedUser = _userService.Get(id);
            if (foundedUser != null)
            {
                var fullName = $"{foundedUser.FirstName}{foundedUser.LastName}.txt";
                File.Create(fullName).Close();
            }
            _mutex.ReleaseMutex();

        });
    }
}