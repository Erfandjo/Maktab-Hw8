using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Contains
{
    public interface IOperatorService
    {
        public Result ActiveUser(int userId);
        public Result InActiveUser(int userId);
        public Result ChangeQuantoty(int courseId , int quantity);
    }
}
