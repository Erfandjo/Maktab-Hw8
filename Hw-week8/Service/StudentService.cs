using Hw_week8.Contains;
using Hw_week8.Entities;
using Hw_week8.Repositories;

namespace Hw_week8.Service
{
    public class StudentService : IStudentService
    {
        ICourseRepositry CourseRepo;
        IUserRepositry UserRepo;


        public StudentService()
        {
            CourseRepo = new CourseRepositry();
            UserRepo = new UserRepositry();

        }

        public void GetSelectList()
        {
            var onlineUser = (Student)UserRepo.GetOnlineUser();
            foreach (var course in onlineUser.Courses)
            {
                Console.WriteLine($"Id : {course.Id} , Name : {course.Name} , Unit : {course.Unit} , Teacher : {course.Teacher.FirstName} , Teacher : {course.Teacher.LastName} , Date Start : {course.DateStart} , Date End : {course.DateEnd}");
            }
        }

        public Result SelectCourse(int id)
        {
            var onlineUser = (Student)UserRepo.GetOnlineUser();
            foreach (var c in CourseRepo.Gets())
            {
                if (c.Id == id)
                {
                    if (c.Quantity > 0)
                    {
                        if (onlineUser.MyUnit + c.Unit <= 20)
                        {
                            if (CheckTime(c).IsSucces)
                            {
                                if (!Check(id))
                                {
                                    onlineUser.Courses.Add(c);
                                    onlineUser.MyUnit += c.Unit;
                                    c.Quantity--;
                                    c.Students.Add(onlineUser);
                                    return new Result(true);
                                } else
                                {
                                    return new Result(false , "Course Before Selected");
                                }
                            }
                            else
                            {
                                return new Result(false, CheckTime(c).Message);
                            }

                        }
                        else
                        {
                            return new Result(false, "Max Unit = 20");
                        }
                    }
                    else
                    {
                        return new Result(false, "It has no Quantity");
                    }
                }
            }
            return new Result(false, "Not Found Course");
        }

        public Result CheckTime(Course c)
        {
            var onlineUser = (Student)UserRepo.GetOnlineUser();
            foreach (var course in onlineUser.Courses)
            {
                if (course.DateEnd.Hour > c.DateStart.Hour && course.DateStart.Hour < c.DateStart.Hour)
                {
                    return new Result(false, "Tadakhol Zamani");
                }
                else if (course.DateEnd.Hour == c.DateStart.Hour && course.DateEnd.Minute > c.DateStart.Minute)
                {
                    return new Result(false, "Tadakhol Zamani");
                }
            }
            return new Result(true);
        }


        public bool Check(int id)
        {
            var onlineUser = (Student)UserRepo.GetOnlineUser();
            foreach (var c in onlineUser.Courses)
            {
                if (c.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
