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
        private readonly Event eventBase = new()
        {
            EventId = 1,
            Name = "Piłkarze",
            Description = "Bardzo lubimy grać w piłkę nożną",
            Date = DateTime.MaxValue,
            IsOpen = true,
            AdministratorId = 1,
            PicturePath = "/Pictures/pilkarz.jpg"
        };

        [Fact]
        public async Task EventRepository_AddEvent_ReturnAddedEventById()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<EventsRepository>>();
            var repository = new EventsRepository(context, loggerMock.Object);

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

            // Act
            await repository.AddEventAsync(eventBase);
            await context.SaveChangesAsync();
            var teamReturned = repository.GetEventsForUserQueryable(1).ToList();

            //Assert
            teamReturned.Should().NotBeNullOrEmpty();
        }
    }
}

