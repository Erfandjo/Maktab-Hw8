using Hw_week8.Contains;
using Hw_week8.Data;
using Hw_week8.Entities;

namespace Hw_week8.Repositories
{
    public class UserRepositry : IUserRepositry
    {
        public List<User> Get()
        {
            return Storage.Users;
        }



        public User GetOnlineUser()
        {
            return Storage.OnlineUser;
        }

        public void Login(User user)
        {
            Storage.OnlineUser = user;
        }

        public void LogOut()
        {
            Storage.OnlineUser = null;
        }

        public void Register(User user)
        {
            Storage.Users.Add(user);
        }
    }
}
