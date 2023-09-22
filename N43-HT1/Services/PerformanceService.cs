using N43_HT1.Services.Interfaces;

namespace N43_HT1.Services;

public class PerformanceService : IPerformanceService
{
    private readonly IUserService _userService;
    private Mutex _mutex = new(false, "mutex");

    public PerformanceService(IUserService userService)
    {
        _userService = userService;
    }

    public Task<bool> ReportPerformanceAsync(Guid id)
    {
        return Task.Run(() =>
        {
            _mutex.WaitOne();
            var foundedUser = _userService.Get(id);

            if (foundedUser != null)
            {
                var fullName = $"{foundedUser.FirstName}{foundedUser.LastName}.txt";
                File.WriteAllText(fullName, "All good :)");
                return true;
            }
            
            return false;
            _mutex.ReleaseMutex();
        });
    }
}