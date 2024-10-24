// See https://aka.ms/new-console-template for more information
using Hw_week8.Contains;
using Hw_week8.Data;
using Hw_week8.Entities;
using Hw_week8.Enum;
using Hw_week8.Repositories;
using Hw_week8.Service;
using System.Globalization;


Authentication authentication = new Authentication();
IUserRepositry repo = new UserRepositry();
CourseService courseService = new CourseService();
StudentService studentService = new StudentService();
TeaherService teacherService = new TeaherService();
UserService userService = new UserService();
OperatorService operatorService = new OperatorService();



SeedData.Seed();
MainMenu();




void MainMenu()
{
    Console.Clear();
    Console.WriteLine("*********************************");
    Console.WriteLine("             Main");
    Console.WriteLine("*********************************");
    Console.Write("Please Select (1:Login , 2:Register) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int authentication))
    {
        Console.WriteLine("Selected Invalid.");
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
        MainMenu();
    }
    if (authentication > 0 && authentication < 3)
    {
        switch (authentication)
        {
            case 1:
                LoginMenu();
                break;
            case 2:
                RegisterMenu();
                break;
        }
    }
    else
    {
        Console.WriteLine("Selected Invalid.");
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
        MainMenu();
    }
}
void LoginMenu()
{
    Console.Clear();
    Console.WriteLine("*********************************");
    Console.WriteLine("             Login");
    Console.WriteLine("*********************************");
    Console.Write($"Please Select Your Role({(int)RoleEnum.Student}:{RoleEnum.Student} , {(int)RoleEnum.Operator}:{RoleEnum.Operator} , {(int)RoleEnum.Teacher}:{RoleEnum.Teacher}) : ");

    if (!Int32.TryParse(Console.ReadLine(), out int roleId))
    {
        Console.WriteLine("Selected Role Is Invalid.");
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
        LoginMenu();
    }
    RoleEnum roleEnum = (RoleEnum)roleId;

    if (roleId > 0 && roleId <= 3)
    {
        Console.Write("Please Enter UserName : ");
        var userName = Console.ReadLine();
        Console.Write("Please Enter Password : ");
        var password = Console.ReadLine();
        var login = authentication.Login(userName, password);
        if (!login.IsSucces)
        {
            Console.WriteLine(login.Message);
            Console.WriteLine("Please Select Any Key : ");
            Console.ReadKey();
            MainMenu();
        }
        else
        {
            switch (roleEnum)
            {
                case RoleEnum.Student:
                    StudentMenu();
                    break;
                case RoleEnum.Operator:
                    OperatorMenu();
                    break;

                case RoleEnum.Teacher:
                    TeacherMenu();
                    break;

            }
        }
    }
    else
    {
        Console.WriteLine("Selected Role Is Invalid.");
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
        LoginMenu();
    }

}
void RegisterMenu()
{
    Console.Clear();
    Console.WriteLine("*********************************");
    Console.WriteLine("             Register");
    Console.WriteLine("*********************************");
    Console.Write($"Please Select Your Role({(int)RoleEnum.Student}:{RoleEnum.Student} , {(int)RoleEnum.Operator}:{RoleEnum.Operator} , {(int)RoleEnum.Teacher}:{RoleEnum.Teacher}) : ");
    if (!Int32.TryParse(Console.ReadLine(), out int roleId))
    {
        Console.WriteLine("Selected Role Is Invalid.");
        RegisterMenu();
    }
    RoleEnum roleEnum = (RoleEnum)roleId;

    if (roleId > 0 && roleId <= 3)
    {
        Console.Write("Please Enter First Name : ");
        string firstName = Console.ReadLine();
        Console.Write("Please Enter Last Name : ");
        string lastName = Console.ReadLine();
        Console.Write("Please Enter Email : ");
        var email = Console.ReadLine();
        Console.Write("Please Enter Password : ");
        var password = Console.ReadLine();
        User user = null;
        switch (roleEnum)
        {
            case RoleEnum.Student:
                user = new Student(firstName, lastName, email);
                break;
            case RoleEnum.Operator:
                user = new Operator(firstName, lastName, email);
                break;

            case RoleEnum.Teacher:
                user = new Teacher(firstName, lastName, email);
                break;
        }

        var Register = authentication.Register(user, password);
        if (!Register.IsSucces)
        {
            Console.WriteLine(Register.Message);
            Console.WriteLine("Please Select Any Key : ");
            Console.ReadKey();
            RegisterMenu();
        }
        else
        {
            MainMenu();
        }
    }
    else
    {
        Console.WriteLine("Selected Role Is Invalid.");
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
        RegisterMenu();
    }

}
void StudentMenu()
{
    Console.Clear();
    if (repo.GetOnlineUser() is not null && repo.GetOnlineUser() is Student)
    {
        Console.WriteLine("**********************");
        Console.WriteLine("          Student Menu");
        Console.WriteLine("**********************");
        Console.WriteLine("1) Get All Course");
        Console.WriteLine("2) Course Selection");
        Console.WriteLine("3) Get Course Selection");
        Console.WriteLine("4) Log Out");
        Console.Write($"Please Select Your Number : ");
        if (!Int32.TryParse(Console.ReadLine(), out int option))
        {
            Console.WriteLine("Selected option Is Invalid.");
            StudentMenu();
        }
        switch (option)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("**********************");
                courseService.GetAllCourse();
                Console.WriteLine("**********************");
                Console.WriteLine("Please Select Any Key : ");
                Console.ReadKey();
                StudentMenu();
                break;
            case 2:
                SelectCourseMenu();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("***************Selected Course**************");
                studentService.GetSelectList();
                Console.WriteLine("***************Selected Course**************");
                Console.WriteLine("Please Select Any Key : ");
                Console.ReadKey();
                StudentMenu();
                break;
            case 4:
                repo.LogOut();
                MainMenu();
                break;

        }
    }
    else
    {
        Console.WriteLine("Access Denid.");
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
        MainMenu();
    }
}
void TeacherMenu()
{
    Console.Clear();
    if (repo.GetOnlineUser() is not null && repo.GetOnlineUser() is Teacher)
    {
        Console.WriteLine("********************************");
        Console.WriteLine("          Teacher Menu");
        Console.WriteLine("*********************************");
        Console.WriteLine("1) Add Course");
        Console.WriteLine("2) Get Student Course Selection");
        Console.WriteLine("3) Log Out");
        Console.Write($"Please Select Your Number : ");
        if (!Int32.TryParse(Console.ReadLine(), out int option2))
        {
            Console.WriteLine("Selected option Is Invalid.");
            TeacherMenu();
        }
        switch (option2)
        {
            case 1:
                Console.Write("Please Enter Name : ");
                string name = Console.ReadLine();
                Console.Write("Please Enter Unit : ");
                int unit = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please Enter Quantity : ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please Enter Hour Start : ");
                int hourStart = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please Enter Minute Start : ");
                int minuteStart = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please Enter Hour End : ");
                int hourEnd = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please Enter Minute End : ");
                int minuteEnd = Convert.ToInt32(Console.ReadLine());

                Course course = new Course(name, unit, (Teacher)repo.GetOnlineUser(), quantity, new TimeOnly(hourStart, minuteStart), new TimeOnly(hourEnd, minuteEnd));
                var onlineUser = (Teacher)repo.GetOnlineUser();
                onlineUser.Courses.Add(course);
                teacherService.AddCourse(course);
                TeacherMenu();
                break;
            case 2:
                teacherService.GetStudents();
                Console.WriteLine("Please Select Any Key : ");
                Console.ReadKey();
                TeacherMenu();
                break;
            case 3:
                repo.LogOut();
                MainMenu();
                break;
        }

    }
    else
    {
        Console.WriteLine("Access Denid.");
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
        MainMenu();
    }
}
void OperatorMenu()
{
    Console.Clear();
    if (repo.GetOnlineUser() is not null && repo.GetOnlineUser() is Operator)
    {
        Console.WriteLine("********************************");
        Console.WriteLine("          Operator Menu");
        Console.WriteLine("*********************************");
        Console.WriteLine("1) Active User");
        Console.WriteLine("2) InActive User");
        Console.WriteLine("3) Change Quantity");
        Console.WriteLine("4) Log Out");
        Console.Write($"Please Select Your Number : ");
        if (!Int32.TryParse(Console.ReadLine(), out int option))
        {
            Console.WriteLine("Selected option Is Invalid.");
            TeacherMenu();
        }
        switch (option)
        {
            case 1:
                Console.WriteLine("********************************");
                Console.WriteLine("          Active User");
                Console.WriteLine("*********************************");
                userService.GetInActiveUser();
                Console.Write("Please Enter For Id :");
                int userId = Convert.ToInt32(Console.ReadLine());
                operatorService.ActiveUser(userId);
                OperatorMenu();
                break;
                case 2:
                Console.WriteLine("********************************");
                Console.WriteLine("          InActive User");
                Console.WriteLine("*********************************");
                userService.GetActiveUser();
                Console.Write("Please Enter For Id :");
                int userId2 = Convert.ToInt32(Console.ReadLine());
                operatorService.InActiveUser(userId2);
                OperatorMenu();
                break;
                case 3:
                courseService.GetAllCourse();
                Console.Write("Please Enter For Id :");
                int courseId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please Enter Quantity : ");
                int quantity = Convert.ToInt32(Console.ReadLine());
                operatorService.ChangeQuantoty(courseId, quantity);
                OperatorMenu();
                break;
                case 4:
                repo.LogOut();
                MainMenu();
                break;

        }
    }
    else
    {
        Console.WriteLine("Access Denid.");
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
        MainMenu();
    }
}
void SelectCourseMenu()
{
    Console.Clear();
    Console.WriteLine("***************Selected Course**************");
    studentService.GetSelectList();
    Console.WriteLine("***************Selected Course**************");
    Console.WriteLine("***************Accssible Course*****************************");
    courseService.GetAllCourse();
    Console.WriteLine("***************Accssible Course*****************************");
    Console.Write("Please Select Id (Exit = 0) : ");

    if (!Int32.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Id Is Incorrect");
        SelectCourseMenu();
    }
    if (id == 0)
    {
        StudentMenu();
    }
    var result = studentService.SelectCourse(id);
    if (!result.IsSucces)
    {
        Console.WriteLine(result.Message);
        Console.WriteLine("Please Select Any Key : ");
        Console.ReadKey();
    }

    SelectCourseMenu();
}

Console.WriteLine();

