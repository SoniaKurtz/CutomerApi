using System;

namespace CustomerWebApi.Dto
{
    public class CustomerDto
    {
        public Guid Id {get; set;}
        public string FirstName{get; set;}
        public string LastName {get; set;}
        public string TelephoneNumber {get; set;}
        public string Address {get; set;}
    }
}