using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.Infrastructure.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        public Task AddEventAsync(Event eventTobase);

        public Task<IQueryable<Event>> GetAvailableEventsAsync(int loggedUserId);

        public Task<Event> GetEventByIdAsync(int id);

        public Task DeleteEventByIdAsync(int id);

        public Task DeleteEventFromCalendarByIdAsync(int id, int userId);

        public Task UpdateEventAsync(Event eventToBase);

        public Task<bool> CheckIfLoggedUserIsParticipantAsync(int loggedUserId, int eventId);

        public Task AddEventForUserAsync(int applicationUserId, int eventId);

        public Task<IQueryable<Event>> GetEventsForUserAsync(int applicationUserId);

        public Task<IQueryable<ApplicationUser>> GetApplicationUsersForEventAsync(int eventId);
    }
}
