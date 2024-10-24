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
    public class CourseService : ICourseService
    {
        public ICourseRepositry repo;

        public CourseService()
        {
            repo = new CourseRepositry();
        }

        public void GetAllCourse()
        {
            List<Course> c = repo.Gets();
            foreach (Course course in c)
            {
                Console.WriteLine($"Id : {course.Id} , Name : {course.Name} , Unit : {course.Unit} , Teacher : {course.Teacher.FirstName} {course.Teacher.LastName} , Quantity : {course.Quantity} , Time Start : {course.DateStart} , Time End : {course.DateEnd}");
            }
        }


    }
}
