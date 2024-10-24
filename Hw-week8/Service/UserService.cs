using Hw_week8.Contains;
using Hw_week8.Repositories;

namespace Hw_week8.Service
{
    public class UserService : IUserService
    {
        IUserRepositry UserRepo;
        public UserService()
        {
            UserRepo = new UserRepositry();
        }
        public void GetActiveUser()
        {
            foreach (var u in UserRepo.Get())
            {
                if (u.IsActive)
                {
                    Console.WriteLine($"Id : {u.Id} , Name : {u.FirstName} {u.LastName} , User Name : {u.UserName} , Active : {u.IsActive}");
                }
            }
        }

        public void GetInActiveUser()
        {
            foreach (var u in UserRepo.Get())
            {
                if (!u.IsActive)
                {
                    Console.WriteLine($"Id : {u.Id} , Name : {u.FirstName} {u.LastName} , User Name : {u.UserName} , Active : {u.IsActive}");
                }
            }
        }
    }
}
