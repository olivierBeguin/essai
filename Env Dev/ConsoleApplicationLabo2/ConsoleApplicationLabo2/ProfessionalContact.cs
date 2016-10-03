using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class ProfessionalContact : Person
    {
        public string Job { get; set; }
        public string ProfessionalNumber { get; set; }
        public string ProfessionalMail { get; set; }
        public List<Entreprise> ListEntreprises {get; set;}

        public ProfessionalContact(string name, string lastName, string job, string professionalNumber, string professionalMail):base(name, lastName)
        {
            Job = job;
            ProfessionalNumber = professionalNumber;
            ProfessionalMail = professionalMail;
            ListEntreprises = new List<Entreprise>();
        }

        public override string ToString()
        {
            return base.ToString() + "("+ ProfessionalNumber + ")\n"+Job +"\n"+ProfessionalMail;
        }

        public override bool HasHisBirthday()
        {
            return false;
        }

        public void EntrepriseAdd(Entreprise entreprise)
        {
            ListEntreprises.Add(entreprise);
        }

        public string Print()
        {
            return base.ToString() + " est un contact professionnel";
        }
    }
}
