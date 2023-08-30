using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        public Task AddEventAsync(Event eventTobase);

        public Task SaveDataAsync();

        public Task<List<Event>> GetAvailableEventsAsync(int loggedUserId);

        public Task<Event> GetEventByIdAsync(int id);

        public Task DeleteEventByIdAsync(int id);

        public Task DeleteEventFromCalendarByIdAsync(int id, int userId);

        public Task UpdateEventAsync(Event eventToBase);

        public Task<bool> CheckIfLoggedUserIsParticipantAsync(int loggedUserId, int eventId);

        public Task AddEventForUserAsync(int applicationUserId, int eventId);

        public Task<List<Event>> GetEventsForUserAsync(int applicationUserId);

        public Task<List<ApplicationUser>> GetApplicationUsersForEventAsync(int eventId);
    }
}
