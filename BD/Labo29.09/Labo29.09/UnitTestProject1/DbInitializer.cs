using Labo29._09;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class DbInitializer : DropCreateDatabaseAlways<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            Customer customer = new Customer()
            {
                AccountBalance = 100,
                AddressLine1 = "adresse1",
                City = "Namur",
                Country = "Belgique",
                Id = 454,
                EMail = "dko@sdovg.com",
                Name = "Augu",
                PostCode = "5650",
                Remark = "Mort"
            };
            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}
