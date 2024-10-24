using Hw_week8.Contains;
using Hw_week8.Repositories;

namespace Hw_week8.Entities
{
    public class Teacher : User
    {
        IUserRepositry Repo = new UserRepositry();
        public Teacher(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {

            Id = GetId();

        }

        public List<Course> Courses { get; set; } = new List<Course>();
        public int Id { get; set; }

        private int GetId()
        {
            int id = 1;
            foreach (var t in Repo.Get())
            {
                if (t is Teacher)
                {
                    id++;
                }

            }
            return id;
        }
    }
}
