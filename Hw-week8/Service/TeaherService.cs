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
    public class TeaherService : ITeacherService
    {
        ICourseRepositry RepoCo;
        ITeacherRepositry Repoth;
        IUserRepositry RepoUs;

        public TeaherService()
        {
            RepoCo = new CourseRepositry();
            Repoth = new TeacherRepositry();
            RepoUs = new UserRepositry();
        }
        public void AddCourse(Course cource)
        {
            RepoCo.Add(cource);
        }

        public void GetAllTeacher()
        {
            foreach(var th in Repoth.Get())
            {
                Console.WriteLine($"Id : {th.Id} , Name : {th.FirstName} {th.LastName}");
            }
        }

        public Teacher FindTeacherById(int id)
        {
           foreach(var th in Repoth.Get())
            {
                if(th.Id == id)
                {
                    return th;
                }
            }
            return null;
        }

        public void GetStudents()
        {
            var onlineUser = (Teacher) RepoUs.GetOnlineUser();
            foreach (var th in onlineUser.Courses)
            {
                Console.WriteLine($"Name Course : {th.Name} , Id Course : {th.Id}");
                
                foreach (var st in th.Students)
                {
                    Console.WriteLine($"Name : {st.FirstName} {st.LastName} , Id = {st.Id}");
                }
                Console.WriteLine("****************************************************");
            }
        }
    }
}
