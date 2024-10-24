using Hw_week8.Contains;
using Hw_week8.Data;
using Hw_week8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Repositories
{
    internal class CourseRepositry : ICourseRepositry
    {
        public void Add(Course course)
        {
            Storage.Courses.Add(course);
        }

        public List<Course> Gets()
        {
            return Storage.Courses;
        }


    }
}
