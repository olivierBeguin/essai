using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class Entreprise
    {
        public string Name { get; set; }
        public string PlaceCentral { get; set; }

        public Entreprise(string name, string placeCentral)
        {
            Name = name;
            PlaceCentral = placeCentral;
        }

        public override string ToString()
        {
            return Name + " " + PlaceCentral;
        }
    }
}
