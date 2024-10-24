using Hw_week8.Contains;
using Hw_week8.Repositories;

namespace Hw_week8.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        protected string Password { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }





        IUserRepositry  repo = new UserRepositry();

       

        protected User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = email;
            IsActive = false;
            Id = GetId();
        }

        public virtual Result SetPassword(string password)
        {
            if (password.Length >= 3)
            {
                Password = password;
                return new Result(true);
            }
            return new Result(false, "Password Must Be More Than 3 Characters");
        }

        public Result CheckPassword(string password)
        {
            if (Password == password)
            {
                return new Result(true);
            }
            return new Result(false);

        }


        private int GetId()
        {
            int id = 1;
            foreach (var user in repo.Get())
            {
                id++;
            }
            return id;
        }
    }
}
