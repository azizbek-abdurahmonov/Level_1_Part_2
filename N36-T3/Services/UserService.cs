using N36_T3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_T3.Services
{
    public class UserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public void CreateUser(User user)
        {
            _users.Add(user);
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User GetUser(Guid Id)
        {
            return _users.FirstOrDefault(user => user.Id == Id);
        }

        public void UpdateUser(User updatedUser)
        {
            var foundedUser = _users.FirstOrDefault(user => user.Id == updatedUser.Id);

            if (foundedUser != null)
            {
                foundedUser.FirstName = updatedUser.FirstName;
                foundedUser.LastName = updatedUser.LastName;
            }
        }

        public void DeleteUser(Guid Id)
        {
            var foundedUser = _users.FirstOrDefault(user => user.Id == Id);
            if (foundedUser != null)
                _users.Remove(foundedUser);
        }
    }
}
