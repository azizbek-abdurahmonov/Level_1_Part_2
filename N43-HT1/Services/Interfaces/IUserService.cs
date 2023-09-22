using N43_HT1.Models;

namespace N43_HT1.Services.Interfaces;

public interface IUserService
{
    User Create(User user);
    bool Delete(Guid id);
    User Get(Guid id);
    User Update(User user);
    List<User> GetAll();
}