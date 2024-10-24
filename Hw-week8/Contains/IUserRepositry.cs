using Hw_week8.Entities;

namespace Hw_week8.Contains
{
    public interface IUserRepositry
    {
        public List<User> Get();

        public void Login(User user);
        public void Register(User user);
        public User GetOnlineUser();

        public void LogOut();

        
    }
}
