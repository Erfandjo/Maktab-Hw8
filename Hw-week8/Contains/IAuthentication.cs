using Hw_week8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Contains
{
    public interface IAuthentication
    {
        public Result Login(string username, string password);
        public Result Register(User user, string pass);
    }
}
