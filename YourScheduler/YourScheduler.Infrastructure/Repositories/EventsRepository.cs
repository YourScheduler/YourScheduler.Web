using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        private readonly ILogger _logger;

        public EventsRepository(YourSchedulerDbContext dbContext, ILogger<EventsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Event> AddEventAsync(Event eventTobase)
        {
            _logger.LogInformation("User attempt to add new event at {DT}", DateTime.Now.ToLongTimeString());
            await _dbContext.Events.AddAsync(eventTobase);
            return eventTobase;
        }

        public IQueryable<Event> GetAvailableEventsQueryable(int loggedUserId)
        {
            _logger.LogInformation("User attempt to get available events at {DT}", DateTime.Now.ToLongTimeString());
            IQueryable<Event> events = _dbContext.Events.Where(i => i.IsOpen == true || i.AdministratorId == loggedUserId);
            return events;
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            _logger.LogInformation("User attempt to get event by ID at {DT}", DateTime.Now.ToLongTimeString());
            var returnedEvent = await _dbContext.Events.FirstOrDefaultAsync(x => x.EventId == id);
            if (returnedEvent is null)
            {
                throw new Exception("Could not find event by provided id");
            }
            return returnedEvent;
        }

        public async Task DeleteEventByIdAsync(int id)
        {
            _logger.LogInformation("User attempt to delete event by ID at {DT}", DateTime.Now.ToLongTimeString());
            var eventToDelete = await GetEventByIdAsync(id);
            {
                _dbContext.Events.Remove(eventToDelete);
                var applicationUserEventsToDelete = _dbContext.ApplicationUsersEvents.Where(x => x.EventId == eventToDelete.EventId);
                _dbContext.ApplicationUsersEvents.RemoveRange(applicationUserEventsToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteEventFromCalendarByIdAsync(int id, int userId)
        {
            _logger.LogInformation("User attempt to delete event from calendar by ID at {DT}", DateTime.Now.ToLongTimeString());
            var eventToDelete = await GetEventByIdAsync(id);
            var usersCallendarEventToDelete = await _dbContext.ApplicationUsersEvents.SingleOrDefaultAsync(x=>x.EventId == eventToDelete.EventId && x.ApplicationUserId == userId);
            if (usersCallendarEventToDelete is null)
            {
                throw new Exception("Could not find event with specified id in user's callendar");
            }
            _dbContext.ApplicationUsersEvents.Remove(usersCallendarEventToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Event> UpdateEventAsync(Event eventToBase)
        {
            _logger.LogInformation("User attempt to update event at {DT}", DateTime.Now.ToLongTimeString());

            var eventToUpdate = await GetEventByIdAsync(eventToBase.EventId);
            eventToUpdate.Name = eventToBase.Name;
            eventToUpdate.Description = eventToBase.Description;
            eventToUpdate.Date = eventToBase.Date;
            eventToUpdate.IsOpen = eventToBase.IsOpen;
            eventToUpdate.AdministratorId = eventToBase.AdministratorId;

            if(eventToBase.PicturePath is null)
            {
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                eventToUpdate.PicturePath = eventToBase.PicturePath;
                await _dbContext.SaveChangesAsync();
            }
            return eventToUpdate;
        }

        public async Task<bool> CheckIfLoggedUserIsParticipantAsync(int loggedUserId, int eventId)
        {
            return await _dbContext.ApplicationUsersEvents.AnyAsync(e => e.ApplicationUserId == loggedUserId && e.EventId == eventId);
        }

        public async Task AddEventForUserAsync(int applicationUserId, int eventId)
        {
            _logger.LogInformation("User attempt to add event to own calendar at {DT}", DateTime.Now.ToLongTimeString());

            await _dbContext.ApplicationUsersEvents.AddAsync(new ApplicationUserEvents { ApplicationUserId = applicationUserId, EventId = eventId });
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Event> GetEventsForUserQueryable(int applicationUserId)
        {
            IQueryable<Event> events = _dbContext.ApplicationUsersEvents.Where(x => x.ApplicationUserId == applicationUserId).Select(x => x.Event);
            return events;
        }

        public IQueryable<ApplicationUser> GetApplicationUsersForEventQueryable(int eventId)
        {
            _logger.LogInformation("User attempt to get list of users for event {DT}", DateTime.Now.ToLongTimeString());
            IQueryable<ApplicationUser> applicationUsers = _dbContext.ApplicationUsersEvents.Where(x => x.EventId == eventId).Select(x => x.ApplicationUser);
            return applicationUsers;
        }
    }
}
