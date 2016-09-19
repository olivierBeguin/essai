using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo1
{
    class Pupil : Person
    {
        public int Grade { get; set; }
        private List<Activity> ListActivities;
        private char[] tabEval;
        internal List<Activity> ListActivities1
        {
            get
            {
                return ListActivities;
            }

            set
            {
                ListActivities = value;
            }
        }
        public char[] TabEval
        {
            get
            {
                return tabEval;
            }

            set
            {
                tabEval = value;
            }
        }

        public Pupil(String name, int age, int grade) : base(name, age)
        {
            Grade = grade;
            ListActivities = new List<Activity>();
            TabEval = new char[10];
        }

        public Pupil(String name, int age):this(name, age, 1)
        {

        }
         
        public void AddActivity(Activity activity)
        {
            ListActivities.Add(activity);
        }

        public override string ToString()
        {
            String ch = base.ToString();
            int cptActivities = ListActivities.Count();
            if(cptActivities == 0)
            {
                ch += "n'a pas encore choisi d'activité \n";
            }
            else
            {
                ch += "a choisi les activités suivantes : \n";
                foreach (Activity activity in ListActivities)
                {
                    ch += activity.ToString() +"\n";
                }
            }
            return ch;
        }
        
        public void AddEvaluation(String title = null, char evaluation = 'S')
        {
            int i = 0;
            while (ListActivities.ElementAt(i).Title != title || i < Parameter.constSymb)
            {
                i++;
            }
        }
    }
}
