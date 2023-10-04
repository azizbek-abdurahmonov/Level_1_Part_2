using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services.Interfaces;

public interface IUserService
{
    User Create(User user);
    
    User Update(User user);
    
    User Get(Guid id);
    
    List<User> GetAll();
    
    void Delete(Guid id);
    
    void Delete(User user);
}