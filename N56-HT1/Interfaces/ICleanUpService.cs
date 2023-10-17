using N56_HT1.Models;

namespace N56_HT1.Interfaces;

public interface ICleanUpService
{
    ValueTask<List<string>> CleanAsync(User user);
}
