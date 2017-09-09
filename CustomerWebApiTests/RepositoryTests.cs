using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerWebApi.Repository;
using CustomerWebApi.Domain;
using System;
using CustomerWebApi.Domain.Faults;

namespace CustomerWebApiTests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void Repository_Add_NewCustomer()
        {
            // Given
            var customer = new Customer(Guid.NewGuid(), "Julieta", "Haberjam", "547057507", "1946 Coleman Junction");
            var repo = new CustomerRepository();

            // When
            repo.InsertCustomer(customer);

            // Then
            CollectionAssert.Contains(repo.GetCustomers(), customer);
        }

        [TestMethod]
        public void Repository_Delete_Customer()
        {
            // Given
            var customer = new Customer(Guid.NewGuid(), "Julieta", "Haberjam", "547057507", "1946 Coleman Junction");
            var repo = new CustomerRepository();
            repo.InsertCustomer(customer);

            // When
            repo.DeleteCustomer(customer.Id);

            // Then
            CollectionAssert.DoesNotContain(repo.GetCustomers(), customer);
        }

        [TestMethod]
        [ExpectedException(typeof(CustomerNotFound))]
        public void Repository_Delete_NotExistingCustomer()
        {
            // Given
            var repo = new CustomerRepository();

            // When
            repo.DeleteCustomer(Guid.NewGuid());
        }

        [TestMethod]
        public void Repository_Update_Customer()
        {
            // Given
            var customer = new Customer(Guid.NewGuid(), "Julieta", "Haberjam", "547057507", "1946 Coleman Junction");
            var repo = new CustomerRepository();
            repo.InsertCustomer(customer);

            // When
            repo.UpdateCustomer(new Customer(customer.Id, "Felicia", "Haberjam", "547057507", "1946 Coleman Junction"));

            // Then
            var updatedCustomer = repo.GetCustomers().Find(x => x.Id == customer.Id);
            Assert.AreEqual(updatedCustomer.FirstName, "Felicia");
        }
    }
}
