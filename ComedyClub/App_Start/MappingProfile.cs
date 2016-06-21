using AutoMapper;
using ComedyClub.Core.Dtos;
using ComedyClub.Core.Models;

namespace ComedyClub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Show, ShowDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}