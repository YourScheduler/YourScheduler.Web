
using AutoMapper;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.MappingConfig
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EventDto, Event>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsOpen, opt => opt.MapFrom(src => src.Isopen))
                .ForSourceMember(src => src.ImageFile, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.CanLoggedUserDelete, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.IsLoggedUserParticipant, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.CanLoggedUserEdit, opt => opt.DoNotValidate());

            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Isopen, opt => opt.MapFrom(src => src.IsOpen))
                .ForMember(dest => dest.ImageFile, opt => opt.Ignore())
                .ForMember(dest => dest.CanLoggedUserDelete, opt => opt.Ignore())
                .ForMember(dest => dest.IsLoggedUserParticipant, opt => opt.Ignore())
                .ForMember(dest => dest.CanLoggedUserEdit, opt => opt.Ignore());

            CreateMap<TeamDto, Team>()
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.Id))
                .ForSourceMember(src => src.ImageFile, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.CanLoggedUserDelete, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.IsLoggedUserParticipant, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.CanLoggedUserEdit, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.ImageFile, opt => opt.DoNotValidate());

            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TeamId))
                .ForMember(dest => dest.ImageFile, opt => opt.Ignore())
                .ForMember(dest => dest.CanLoggedUserDelete, opt => opt.Ignore())
                .ForMember(dest => dest.IsLoggedUserParticipant, opt => opt.Ignore())
                .ForMember(dest => dest.CanLoggedUserEdit, opt => opt.Ignore());

            CreateMap<ApplicationUserDto, ApplicationUser>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
            .ForMember(dest => dest.Displayname, opt => opt.MapFrom(src => src.Displayname))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.ApplicationUsersEvents, opt => opt.Ignore())
            .ForMember(dest => dest.ApplicationUsersTeams, opt => opt.Ignore());

            var userDtoMap = CreateMap<ApplicationUser, ApplicationUserDto>();
            userDtoMap.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            userDtoMap.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            userDtoMap.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));
            userDtoMap.ForMember(dest => dest.Displayname, opt => opt.MapFrom(src => src.Displayname));
            userDtoMap.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        }
    }
}
