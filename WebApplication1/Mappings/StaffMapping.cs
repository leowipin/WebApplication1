using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Mappings
{
    public class StaffProfile : Profile
    {
        public StaffProfile() 
        {
            CreateMap<StaffCreationDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<StaffCreationDto, Staff>()
                .ForMember(dest=>dest.Position, opt=>opt.MapFrom(src=>src.Position));
            CreateMap<Staff, StaffDto>()
                .ForMember(dest=>dest.Id, opt=>opt.MapFrom(opt=>opt.Id))
                .ForMember(dest=>dest.Position, opt=>opt.MapFrom(src=>src.Position))
                .ForMember(dest=>dest.Email, opt=>opt.MapFrom(src=>src.User.Email));

        }
    }
}