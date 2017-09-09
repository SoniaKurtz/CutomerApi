using System.Collections.Generic;
using CustomerWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using CustomerWebApi.Dto;
using System.Linq;
using AutoMapper;
using CustomerWebApi.Domain;
using System;

namespace CustomerWebApi.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        public CustomerController(ICustomerRepository repository, IMapper mapper)
        {
            CustomersRecords = repository;
            Mapper = mapper;
        }

        public ICustomerRepository CustomersRecords { get; }

        public IMapper Mapper { get; }

        [HttpGet]
        [Route("CustomerRecords")]
        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            return Mapper.Map<IEnumerable<CustomerDto>>(CustomersRecords.GetCustomers());
        }

        [Route("InsertCustomerRecord")]
        [HttpPut]
        public IEnumerable<CustomerDto> InsertCustomerRecord([FromBody] CustomerDto customer)
        {
            return Mapper.Map<IEnumerable<CustomerDto>>(CustomersRecords.InsertCustomer(Mapper.Map<Customer>(customer)));
        }

        [Route("UpdateCustomerRecord")]
        [HttpPut]
        public IEnumerable<CustomerDto> UpdateCustomerRecord([FromBody] CustomerDto customer)
        {
            return Mapper.Map<IEnumerable<CustomerDto>>(CustomersRecords.UpdateCustomer(Mapper.Map<Customer>(customer)));
        }

        [Route("DeleteCustomerRecord")]
        [HttpDelete]
        public IEnumerable<CustomerDto> DeleteCustomerRecord(Guid customerId)
        {
            return Mapper.Map<IEnumerable<CustomerDto>>(CustomersRecords.DeleteCustomer(customerId));
        }
    }
}