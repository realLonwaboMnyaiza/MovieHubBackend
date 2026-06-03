using AutoMapper;
using MovieHub.API.DTO;
using MovieHub.API.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
    }
}