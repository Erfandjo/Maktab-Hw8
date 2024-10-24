using Hw_week8.Contains;
using Hw_week8.Data;
using Hw_week8.Entities;
using Hw_week8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Service
{
    public class Authentication : IAuthentication
    {
        IUserRepositry Repo;
        public Authentication()
        {
            Repo = new UserRepositry();
        }
        public Result Login(string username, string password)
        {
            foreach (var item in Repo.Get())
            {

                if (item.UserName == username)
                {
                    var result = item.CheckPassword(password);
                    if (result.IsSucces)
                    {
                        if (item.IsActive)
                        {
                            Repo.Login(item);
                            return new Result(true);
                        }
                        else
                        {
                            return new Result(false, "User Is InActive");
                        }
                    }

                }
            }
            return new Result(false, "UserName or Password Incorrect.");
        }

        public Result Register(User user, string pass)
        {
            var Result = user.SetPassword(pass);
            if (Result.IsSucces)
            {
                Repo.Register(user);
                return new Result(true);
            }
            else
            {
                return new Result(false, Result.Message);
            }
        }
    }
}
