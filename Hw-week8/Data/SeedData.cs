using Hw_week8.Entities;

namespace Hw_week8.Data
{
    public static class SeedData
    {

        public static void Seed()
        {
            Student st = new Student("erfan", "jaharzadeh", "ErfanJoharzadeh@gmail.com", 20, Enum.GenderEnum.Male);
            st.SetPassword("123456");
            Storage.Users.Add(st);




            Operator op = new Operator("erfan", "jaharzadeh", "ErfanJoharzadeh@gmail.com", true);
            op.SetPassword("1234567");
            Storage.Users.Add(op);


            Teacher th = new Teacher("farzan", "jaharzadeh", "farzan");
            th.SetPassword("1234567");
            Storage.Users.Add(th);


            Storage.Courses.Add(new Course("akmc", 3, th, 10, new TimeOnly(14, 0), new TimeOnly(16, 20)));
            Storage.Courses.Add(new Course("akmc", 2, th, 1, new TimeOnly(16, 10), new TimeOnly(17, 0)));
            Storage.Courses.Add(new Course("akmc", 1, th, 3, new TimeOnly(11), new TimeOnly(13, 0)));
            Storage.Courses.Add(new Course("akmc", 5, th, 12, new TimeOnly(17, 0), new TimeOnly(19, 0)));
            Storage.Courses.Add(new Course("akmc", 4, th, 10, new TimeOnly(9, 0), new TimeOnly(10, 0)));
            Storage.Courses.Add(new Course("akmc", 2, th, 5, new TimeOnly(8, 0), new TimeOnly(11, 0)));
            Storage.Courses.Add(new Course("akmc", 2, th, 0, new TimeOnly(14), new TimeOnly(16, 0)));

        }

    }
}
