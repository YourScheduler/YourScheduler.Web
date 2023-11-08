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
                .ForMember(dest => dest.IsOpen, opt => opt.MapFrom(src => src.Isopen));

            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Isopen, opt => opt.MapFrom(src => src.IsOpen))
                .ForMember(dest => dest.ImageFile, opt => opt.Ignore())
                .ForMember(dest => dest.CanLoggedUserDelete, opt => opt.Ignore())
                .ForMember(dest => dest.IsLoggedUserParticipant, opt => opt.Ignore())
                .ForMember(dest => dest.CanLoggedUserEdit, opt => opt.Ignore());

            CreateMap<TeamDto, Team>()
                .ForSourceMember(src => src.ImageFile, opt => opt.DoNotValidate())
                .ForMember(dest => dest.TeamMembers, opt => opt.Ignore());

            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.ImageFile, opt => opt.Ignore());

            CreateMap<ApplicationUserDto, ApplicationUser>()
                .ForMember(dest => dest.ApplicationUsersEvents, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicationUsersTeams, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore());


            CreateMap<ApplicationUser, ApplicationUserDto>();

            CreateMap<TeamRole, TeamRoleDto>();

            CreateMap<TeamRoleDto, TeamRole>()
                .ForMember(dest => dest.ApplicationUserTeams, opt => opt.Ignore());

        }
    }
}
