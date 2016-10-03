using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo4.Model
{
    public static class AllStudents
    {
        public static IEnumerable<Student> Students {get; set;}
        public static IEnumerable<Student> GetAllStudents()
        {
            return Students = new List<Student>
            {
                new Student("Anto", 19),
                new Student("Augu", 20),
                new Student("Louis", 21)
            };
        }
    }
}
