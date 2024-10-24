using Hw_week8.Contains;
using Hw_week8.Data;
using Hw_week8.Entities;

namespace Hw_week8.Repositories
{
    public class TeacherRepositry : ITeacherRepositry
    {
        public List<Teacher> Get()
        {
            List<Teacher> teachers = new List<Teacher>();
            foreach (var teacher in Storage.Users)
            {
                if (teacher is Teacher)
                {
                    teachers.Add((Teacher)teacher);
                }
            }
            return teachers;
        }
    }
}
