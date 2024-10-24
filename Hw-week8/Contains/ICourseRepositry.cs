using Hw_week8.Data;
using Hw_week8.Entities;
using System.Data;
using System.Threading.Channels;

namespace Hw_week8.Contains
{
    public interface ICourseRepositry
    {
        public List<Course> Gets();
        public void Add(Course course);
        

    }
}
