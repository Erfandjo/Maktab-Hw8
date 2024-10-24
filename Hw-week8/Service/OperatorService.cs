using Hw_week8.Contains;
using Hw_week8.Entities;
using Hw_week8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Service
{
    public class OperatorService : IOperatorService
    {
        IUserRepositry UserRepo;
        ICourseRepositry CourseRepo;

        public OperatorService()
        {
            UserRepo = new UserRepositry();
            CourseRepo = new CourseRepositry();
        }
        public Result ActiveUser(int userId)
        {

            foreach (var u in UserRepo.Get())
            {
                if (u.Id == userId)
                {
                    u.IsActive = true;
                    return new Result(true);
                }
            }
            return new Result(false, "User Not Found");

        }

        public Result ChangeQuantoty(int courseId, int quantity)
        {
            foreach (var c in CourseRepo.Gets())
            {
                if (c.Id == courseId)
                {
                    c.Quantity = quantity;
                    return new Result(true);
                }
            }
            return new Result(false, "Course Not Found");
        }

        public Result InActiveUser(int userId)
        {
            foreach (var u in UserRepo.Get())
            {
                if (u.Id == userId)
                {
                    u.IsActive = false;
                    return new Result(true);
                }
            }
            return new Result(false, "User Not Found");
        }
    }
}
