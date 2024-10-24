using Hw_week8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Data
{
    public static class Storage
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Course> Courses { get; set; } = new List<Course>();
        public static User OnlineUser { get; set; }

        

    }
}
