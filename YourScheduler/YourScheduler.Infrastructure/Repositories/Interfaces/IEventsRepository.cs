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
        public Task<Event> AddEventAsync(Event eventTobase);

        public IQueryable<Event> GetAvailableEventsQueryable(int loggedUserId);

        public Task<Event> GetEventByIdAsync(int id);

        public Task DeleteEventByIdAsync(int id);

        public Task DeleteEventFromCalendarByIdAsync(int id, int userId);

        public Task<Event> UpdateEventAsync(Event eventToBase);

        public Task<bool> CheckIfLoggedUserIsParticipantAsync(int loggedUserId, int eventId);

        public Task AddEventForUserAsync(int applicationUserId, int eventId);

        public IQueryable<Event> GetEventsForUserQueryable(int applicationUserId);

        public IQueryable<ApplicationUser> GetApplicationUsersForEventQueryable(int eventId);
    }
}
