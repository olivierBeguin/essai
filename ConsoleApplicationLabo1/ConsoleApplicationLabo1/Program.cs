using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pupil louis = new Pupil("Louis", 7);
            Activity math = new Activity("Math", true);
            Activity gratouille = new Activity("Gratouille", false);

            louis.AddActivity(math);
            louis.AddActivity(gratouille);

            System.Console.Write(louis.ToString());
            

            List<Pupil> listPupil = new List<Pupil>()
            {
                new Pupil("Anto", 7, 2),
                new Pupil("Augu", 7),
                new Pupil("Damien", 5),
                new Pupil("Louis", 8),
            };

            List<Person> listPerson = new List<Person>()
            {
                new Person("Coco", 20),
                new Person("Marc", 32),
            };

            /*
            var pupilGrade1plus6 = from pupil in ListPupil
                                   where pupil.Grade == 1 && pupil.Age > 6
                                   select pupil;*/
            var pupilGrade1plus6 = listPupil.Where(Pupil => Pupil.Grade == 1 && Pupil.Age > 6);

            if (pupilGrade1plus6 != null)
            {
                foreach (var pupil in pupilGrade1plus6)
                {
                    System.Console.Write(pupil.ToString());
                    
                }
                System.Console.Read();  
            }

            var listFusion = listPerson.Union(listPupil);

            foreach (var fusion in listFusion)
            {
                fusion.ToString();
            }
        }
    }
}
