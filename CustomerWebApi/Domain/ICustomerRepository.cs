using System.Collections.Generic;
using System;

namespace CustomerWebApi.Domain
{
    public interface ICustomerRepository
    {
         List<Customer> InsertCustomer(Customer customer);
         List<Customer> GetCustomers();
         List<Customer> UpdateCustomer(Customer customer);
         List<Customer> DeleteCustomer(Guid customerId);
    }
}