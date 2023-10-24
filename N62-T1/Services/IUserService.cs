using N62_T1.Models;

namespace N62_T1.Services;

public interface IUserService
{
    ValueTask<User> CreateAsync(User user);
   
    ValueTask<User> GetAsync(Guid userId);
}
