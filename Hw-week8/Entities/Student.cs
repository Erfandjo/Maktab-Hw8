using Hw_week8.Enum;
namespace Hw_week8.Entities
{
    public class Student : User
    {

        public int StudentNO { get; private set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }
        public int MyUnit { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();


        public Student(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
        }

        public Student(string firstName , string lastName , string email  , int age , GenderEnum gender) : this(firstName, lastName , email)
        {
            
            Age = age;
            Gender = gender;
        }

       

        public override Result SetPassword(string password)
        {
            if (password.Length >= 6)
            {
                Password = password;
                return new Result(true);
            }
            return new Result(false, "Password Must Be More Than 6 Characters");
        }
    }
}
