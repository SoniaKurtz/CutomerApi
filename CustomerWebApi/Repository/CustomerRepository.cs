using System.Collections.Generic;
using System.Linq;
using CustomerWebApi.Domain;
using System;
using CustomerWebApi.Domain.Faults;

namespace CustomerWebApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>()
            {
                new Customer (Guid.Parse("b2e7ca9e-9903-4f23-828f-702f617ed561"), "Arabele", "Eckh", "663734791", "73 Schlimgen Road"),
                new Customer (Guid.Parse("e23cee24-d2c1-460e-93ae-c11df5dc7337"), "Devland", "Brunnen", "866369467", "2 Eagan Street"),
                new Customer (Guid.Parse("0b6942eb-cfd4-4de4-b0a1-5d1cc0ed3eb9"), "Star", "Bettison", "420703712", "68552 Heffernan Lane")
            };
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public List<Customer> InsertCustomer(Customer customer)
        {
            customers.Add(customer);
            return customers;
        }

        public List<Customer> UpdateCustomer(Customer customer)
        {
            var customerRecord = customers.Find(c => c.Id == customer.Id);
            if (customerRecord != null)
            {
                customers.Remove(customerRecord);
                customers.Add(customer);
            }
            return customers.OrderBy(o => o.Id).ToList();
        }

        public List<Customer> DeleteCustomer(Guid customerId)
        {
            var customerRecord = customers.Find(c => c.Id == customerId);
            if(customerRecord != null)
            {
                customers.Remove(customerRecord);
            }
            else
            {
                throw new CustomerNotFound();
            }

            return customers;
        }
    }
}