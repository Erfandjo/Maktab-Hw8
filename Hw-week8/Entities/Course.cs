using Hw_week8.Contains;
using Hw_week8.Repositories;

namespace Hw_week8.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public int Quantity { get; set; }
        public TimeOnly DateStart { get; set; } = new TimeOnly();
        public TimeOnly DateEnd { get; set; } = new TimeOnly();

        ICourseRepositry repo = new CourseRepositry();
        


        public Course(string name , int unit , Teacher teacher , int quantity , TimeOnly dateStart , TimeOnly dateEnd)
        {
            Name = name;
            Unit = unit;
            Teacher = teacher;
            Quantity = quantity;
            Id = GetId();
            DateStart = dateStart;
            DateEnd = dateEnd;
            
        }

        
        private int GetId()
        {
            int id = 1;
            foreach (var user in repo.Gets())
            {
                id++;
            }
            return id;
        }
    }
}
