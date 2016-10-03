using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class PrivateContact : Person
    {
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        
        public PrivateContact(string name, string lastName, string phoneNumber, string mail, DateTime birthDate): base(name, lastName)
        {
            PhoneNumber = phoneNumber;
            Mail = mail;
            BirthDate = birthDate;
        }

        public PrivateContact(string name, string lastName, string phoneNumber, string mail) : base(name, lastName)
        {
            PhoneNumber = phoneNumber;
            Mail = mail;
            BirthDate = new DateTime();
        }

        public override string ToString()
        {
            return base.ToString() + "("+PhoneNumber+")\n"+Mail+ (HasHisBirthday()?"\nBon Anniversaire" : "");
        }

        public override bool HasHisBirthday()
        {
            return (DateTime.Today.Month == BirthDate.Month && DateTime.Today.Day == BirthDate.Day);
        }

        public string Print()
        {
            return base.ToString() + " est un contact privé";
        }
    }
}
