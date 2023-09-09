using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public class EventsRepositoryTests
    {

        [Fact]
        public async Task EventRepository_AddEvent_ReturnAddedEventById()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<EventsRepository>>();
            var repository = new EventsRepository(context, loggerMock.Object);
            Event eventBase = new()
            {
                EventId = 1,
                Name = "Piłkarze",
                Description = "Bardzo lubimy grać w piłkę nożną",
                Date = DateTime.MaxValue,
                IsOpen = true,
                AdministratorId = 1,
                PicturePath = "/Pictures/pilkarz.jpg"


            };



            //Act
            await repository.AddEventAsync(eventBase);
            await context.SaveChangesAsync();
            var eventReturned = await repository.GetEventByIdAsync(1);
            //Assert
            eventReturned.EventId.Should().Be(1);
            eventReturned.Name.Should().Be("Piłkarze");



        }

        [Fact]
        public async Task AddEvent_CheckIfListEventsIsNotEmpty()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<EventsRepository>>();
            var repository = new EventsRepository(context, loggerMock.Object);
            Event eventBase = new()
            {
                Name = "Piłkarze",
                Description = "Bardzo lubimy grać w piłkę nożną",
                AdministratorId = 1,
                Date = DateTime.MaxValue,
                EventId = 1,
                IsOpen = true,
                PicturePath = "/Pictures/pilkarz.jpg"
            };


            // Act
            await repository.AddEventAsync(eventBase);
            await context.SaveChangesAsync();
            var teamReturned = repository.GetEventsForUserQueryable(1).ToList();

            //Assert
            teamReturned.Should().NotBeNullOrEmpty();
        }
    }
}

