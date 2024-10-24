using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_week8.Entities
{
    public class Operator : User
    {
        public Operator(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
        }
        public Operator(string firstName, string lastName, string email , bool active) : this(firstName, lastName, email)
        {
            IsActive = active;
        }
    }
}
