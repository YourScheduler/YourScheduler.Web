using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IEventService
    {
        public Task AddEventAsync(EventDto eventDto, int loggedUserId);

        public Task<List<EventDto>> GetAvailableEventsAsync(int loggedUserId, string searchString);

        public Task<EventDto> GetEventByIdAsync(int id, int loggedUserId);

        public Task DeleteEventAsync(int id);

        public Task DeleteEventFromCalendarAsync(int id, int userId);

        public Task UpdateEventAsync(EventDto model, int loggedUserId);

        public Task AddEventForUserAsync(int applicationUserId, int eventId);

        public Task<List<EventDto>> GetMyEventsAsync(int applicationUserId, string searchString);

        //public Task<List<ApplicationUserDto>> GetUsersForEventAsync(int eventId);

        public Task<EventMembersDto> GetEventMembersDtoAsync(int eventId, int loggedUserId);
    }
}
