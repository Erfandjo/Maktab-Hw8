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
    public class StudentRepositry : IStudentRepositry
    {
        public void Add(Student student)
        {
            Storage.Users.Add(student);
        }

        public List<Student> Get()
        {
            List<Student> students = new List<Student>();
            foreach (var student in Storage.Users)
            {
                if (student is Student)
                {
                    students.Add((Student)student);
                }
            }
            return students;
        }



    }
}
