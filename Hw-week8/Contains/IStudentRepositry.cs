using Hw_week8.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Contains
{
    public interface IStudentRepositry
    {
        public List<Student> Get();
        public void Add(Student student);

    }
}
