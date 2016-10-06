using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Labo29._09;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DbInitializer());
            using (CompanyContext context = GetContext())
            {
                context.Database.Initialize(true);
            }
        }

        private CompanyContext GetContext()
        {
            return new CompanyContext();
        }

        [TestMethod]
        public void CanGetCustomers()
        {
            using (var context = GetContext())
            {
                Assert.AreEqual(1, context.Customers.ToList().Count());
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DetectEditionConcurrency()
        {
            CompanyContext contextLouis = GetContext();
            CompanyContext contextOli = GetContext();
            var clientLouis = contextLouis.Customers.First();
            var clientOli = contextOli.Customers.First();

            clientLouis.AccountBalance += 1000;
            contextLouis.SaveChanges();

            clientOli.AccountBalance += 2000;     
            contextOli.SaveChanges();
           
        }
    }
}
