using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrivateContact anto = new PrivateContact("Maniscalco", "Antoni", "0454648625", "anto@hotmail.com");
            PrivateContact louis = new PrivateContact("VDD", "Louis", "048554824", "louisvdd@hotmail.com", new DateTime(1995, 09, 26));
            ProfessionalContact augu = new ProfessionalContact("Willem", "Augu", "Consultant","0498654466", "wille@hotmail.com");
            ProfessionalContact damien = new ProfessionalContact("Jacques", "Damien", "Consultant", "018899456", "damienJacques@skynet.be");
            ProfessionalContact oli = new ProfessionalContact("Beguin", "Olivier", "Indépendant", "0474338503", "oli0795@hotmail.com");
            Entreprise mic = new Entreprise("Microsoft", "Redmond");
            Entreprise apple = new Entreprise("Apple", "Cupertino");
            augu.EntrepriseAdd(mic);
            augu.EntrepriseAdd(apple);
            damien.EntrepriseAdd(mic);
            List<ProfessionalContact> listProfessionalContact = new List<ProfessionalContact>();
            listProfessionalContact.Add(augu);
            listProfessionalContact.Add(damien);
            listProfessionalContact.Add(oli);
            var listContactIndependant = from contact in listProfessionalContact
                                         where contact.Job == "Indépendant"
                                         select contact;



            //Console.WriteLine("Il y a : "+listContactIndependant.Count()+ " indépendant");
            var listContactConsultat = listProfessionalContact.Where(contact => contact.Job == "Consultant" && contact.ListEntreprises.Contains(mic));
            //Console.WriteLine("Il y a : " + listContactConsultat.Count() + " consultant(s) qui travaille chez " + mic);
            //Console.WriteLine(anto.ToString());
            //Console.WriteLine(louis.ToString());

            Car car = new Car("1-FJP-841");
            ContactCar contactCar = new ContactCar(anto, car);
            contactCar.DynamicPrint(anto);

            Car car2 = new Car("1-BEP-345");
            ContactCar contactCar2 = new ContactCar(augu, car2);
            contactCar2.DynamicPrint(augu);
            Console.Read();
        }
    }
}
