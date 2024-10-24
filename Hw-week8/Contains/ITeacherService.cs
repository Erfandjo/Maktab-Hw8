using Hw_week8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Contains
{
    public interface ITeacherService
    {
        public void AddCourse(Course cource);
        public void GetAllTeacher();

        public void GetStudents();
    }
}
