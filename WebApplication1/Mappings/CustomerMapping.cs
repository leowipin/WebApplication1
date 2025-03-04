using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Mappings
{
    public class CustomerProfile : Profile 
    {
        public CustomerProfile() 
        {
            CreateMap<CustomerCreationDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email.Split('@', StringSplitOptions.None)[0]))
                .ForMember(dest=>dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<CustomerCreationDto, Customer>()
                .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName));
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName));
        }
    }
}