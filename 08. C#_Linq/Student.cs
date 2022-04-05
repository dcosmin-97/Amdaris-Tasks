using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Year { get; set; }

        public bool HasAPartTimeJob { get; set; }

        public string FacultyId { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} on year. {Year} {(HasAPartTimeJob ? "Is employed" : "")}";
        }
    }

    public class HomeStudent : Student
    {
        public string Address { get; set; }
    }

    public class Faculty
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string HeadMaster { get; set; }

        public List<Student> Students { get; set; }
    }
}
