using N48_HT1.DataAccess;
using N48_HT1.Models;
using N48_HT1.Services.Interfaces;
using System.Linq.Expressions;

namespace N48_HT1.Services
{
    public class UserService : IUserService
    {
        private IDataContext _dataContext;

        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await _dataContext.Users.AddAsync(user, cancellationToken);

            if (saveChanges)
                await _dataContext.Users.SaveChangesAsync(cancellationToken);

            return user;
        }

        public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var user = await _dataContext.Users.FindAsync(id, cancellationToken);

            if (user == null)
                throw new InvalidOperationException("User not found!");

            await _dataContext.Users.RemoveAsync(user, cancellationToken);

            if (saveChanges)
                await _dataContext.Users.SaveChangesAsync(cancellationToken);

            return user;
        }

        public async ValueTask<User> DeleteAsync(User? user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync((System.Guid)user.Id, saveChanges, cancellationToken);
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _dataContext.Users.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid?> ids, CancellationToken cancellationToken = default)
        {
            var users = _dataContext.Users.Where(user => ids.Contains(user.Id));

            return new ValueTask<ICollection<User>>(users.ToList());
        }

        public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = _dataContext.Users.FirstOrDefault(user => user.Id == id);

            return new ValueTask<User>(user);
        }

        public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundedUser = _dataContext.Users.FirstOrDefault(x => x.Id == user.Id);

            if (foundedUser == null)
                throw new InvalidOperationException("User not found!");

            foundedUser.FirstName = user.FirstName;
            foundedUser.LastName = user.LastName;
            foundedUser.EmailAddress = user.EmailAddress;
            foundedUser.Password = user.Password;

            if (saveChanges)
                await _dataContext.Users.SaveChangesAsync();

            return foundedUser;

        }
    }
}
