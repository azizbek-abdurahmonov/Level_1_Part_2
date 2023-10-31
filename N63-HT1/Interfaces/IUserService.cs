using N63_HT1.Models.Entities;

namespace N63_HT1.Interfaces;

public interface IUserService
{
    ValueTask<User> CreateAsync(User user);

    ValueTask<User> GetByIdAsync(Guid id);

    IQueryable<User> GetAll();
}
