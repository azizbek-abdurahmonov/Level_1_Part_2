using N37_HT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N37_HT1.Services.Interfaces;

namespace N37_HT1.Services
{
    public class UserService : IUserservice
    {
        public List<User> users;

        public UserService()
        {
            users = new List<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            foreach (var user in users)
            {
                yield return user;
            }
        }
    }
}
