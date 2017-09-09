using System;
using CustomerWebApi.Domain.Faults;

namespace CustomerWebApi.Domain
{
    public class Customer
    {
        public Customer(Guid id, string firstName, string lastName, string telephoneNumber, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            Address = address;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public TelephoneNumber TelephoneNumber { get; }
        public string Address { get; }
    }
}