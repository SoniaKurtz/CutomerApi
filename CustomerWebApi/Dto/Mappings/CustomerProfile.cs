using AutoMapper;
using CustomerWebApi.Domain;

namespace CustomerWebApi.Dto.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>().ConstructUsing(x => new Customer(x.Id, x.FirstName, x.LastName, x.TelephoneNumber, x.Address));
            CreateMap<Customer, CustomerDto>();
        }
    }
}