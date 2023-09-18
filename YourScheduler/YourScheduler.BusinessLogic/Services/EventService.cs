using AutoMapper;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Services
{
    public class EventService : IEventService
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly IMapper _mapper;

        public EventService(IEventsRepository eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }

        public async Task AddEventAsync(EventDto eventDto, int loggedUserId)
        {
            eventDto.AdministratorId = loggedUserId;

            await _eventsRepository.AddEventAsync(_mapper.Map<Event>(eventDto));
            await _eventsRepository.SaveDataAsync();
        }

        public async Task<List<EventDto>> GetAvailableEventsAsync(int loggedUserId, string searchString)
        {
            List<EventDto> eventsDto = new List<EventDto>();
            var events = await _eventsRepository.GetAvailableEventsAsync(loggedUserId);
            foreach (var eventFromDatabase in events)
            {
                EventDto eventDto = new EventDto();
                eventDto = _mapper.Map<EventDto>(eventFromDatabase);
                if (loggedUserId == eventDto.AdministratorId)
                {
                    eventDto.CanLoggedUserDelete = true;
                    eventDto.CanLoggedUserEdit = true;
                }
                eventDto.IsLoggedUserParticipant = await _eventsRepository.CheckIfLoggedUserIsParticipantAsync(loggedUserId, eventDto.AdministratorId);
                eventsDto.Add(eventDto);
            }
            if (String.IsNullOrEmpty(searchString))
            {
                return eventsDto;
            }
            else
            {
                return eventsDto.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public async Task<EventDto> GetEventByIdAsync(int id, int loggedUserId)
        {
            var eventFromDataBase = await _eventsRepository.GetEventByIdAsync(id);
            var eventDto = _mapper.Map<EventDto>(eventFromDataBase);
            if (loggedUserId == eventDto.AdministratorId)
            {
                eventDto.CanLoggedUserDelete = true;
                eventDto.CanLoggedUserEdit = true;
            }
            eventDto.IsLoggedUserParticipant = await _eventsRepository.CheckIfLoggedUserIsParticipantAsync(loggedUserId, eventDto.AdministratorId);
            return eventDto;
        }

        public async Task DeleteEventAsync(int id)
        {
            await _eventsRepository.DeleteEventByIdAsync(id);
        }

        public async Task DeleteEventFromCalendarAsync(int id, int userId)
        {
            await _eventsRepository.DeleteEventFromCalendarByIdAsync(id, userId);
        }

        public async Task UpdateEventAsync(EventDto eventDto, int loggedUserId)
        {
            eventDto.AdministratorId = loggedUserId;
            var eventToBase = _mapper.Map<Event>(eventDto);
            await _eventsRepository.UpdateEventAsync(eventToBase);
        }

        public async Task AddEventForUserAsync(int applicationUserId, int eventId)
        {
            await _eventsRepository.AddEventForUserAsync(applicationUserId, eventId);
           // await _eventsRepository.SaveDataAsync();
        }

        public async Task<List<EventDto>> GetMyEventsAsync(int applicationUserId, string searchString)
        {
            List<EventDto> myEvents = new List<EventDto>();
            var eventsForUser =  _eventsRepository.GetEventsForUserQueryable(applicationUserId);
            foreach (var eventEntity in eventsForUser)
            {
                EventDto eventDto = new EventDto();
                eventDto = _mapper.Map<EventDto>(eventEntity);
                if (applicationUserId == eventEntity.AdministratorId)
                {
                    eventDto.CanLoggedUserDelete = true;
                    eventDto.CanLoggedUserEdit = true;
                }
                eventDto.IsLoggedUserParticipant = await _eventsRepository.CheckIfLoggedUserIsParticipantAsync(applicationUserId, eventDto.AdministratorId);
                myEvents.Add(eventDto);
            }
            if (String.IsNullOrEmpty(searchString))
            {
                return myEvents;
            }
            else
            {
                return myEvents.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public async Task<List<ApplicationUserDto>> GetUsersForEventAsync(int eventId)
        {
            List<ApplicationUserDto> usersDtos = new List<ApplicationUserDto>();
            // var usersForEvents = await _eventsRepository.GetApplicationUsersForEventAsync(eventId);

            foreach (var user in usersForEvents)
            {
                var userDto = _mapper.Map<ApplicationUserDto>(user);
                usersDtos.Add(userDto);
            }
            return usersDtos;
        }

        public async Task<EventMembersDto> GetEventMembersDtoAsync(int eventId, int loggedUserId)
        {
            var modelEvent = await GetEventByIdAsync(eventId, loggedUserId);
            EventMembersDto eventMembersDto = new EventMembersDto();
            eventMembersDto.Name = modelEvent.Name;
            eventMembersDto.Description = modelEvent.Description;
            eventMembersDto.Date = modelEvent.Date;
            eventMembersDto.Isopen = modelEvent.Isopen;
            eventMembersDto.EventUsers = await GetUsersForEventAsync(eventId);
            return eventMembersDto;
        }



    }
}
