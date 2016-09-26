using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class Car
    {
        public string NumPlaque { set; get; }
        public Car(string numPlaque)
        {
            NumPlaque = numPlaque;
        }

        public override string ToString()
        {
            return NumPlaque;
        }
    }
}
