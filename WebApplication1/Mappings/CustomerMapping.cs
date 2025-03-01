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
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest=>dest.Email, opt => opt.MapFrom(dest => dest.Email));
            CreateMap<CustomerCreationDto, Customer>()
                .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName));
        }
    }
}