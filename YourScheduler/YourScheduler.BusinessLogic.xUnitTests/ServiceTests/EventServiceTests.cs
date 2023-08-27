using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.xUnitTests.ServiceTests
{
    public class EventServiceTests
    {
        private readonly Mock<IEventsRepository> _eventsRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EventService _eventService;

        public EventServiceTests()
        {
            _eventsRepositoryMock = new Mock<IEventsRepository>();
            _mapperMock = new Mock<IMapper>();
            _eventService = new EventService(_eventsRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task AddTeamAsync_ValidTeamDto_CallsRepositoryAddTeamAsync()
        {
            // Arrange
            var eventDto = new EventDto();
            var eventToDatabase = new Event();
            _mapperMock.Setup(m => m.Map<Event>(eventDto)).Returns(eventToDatabase);

            // Act
            await _eventService.AddEventAsync(eventDto,1);

            // Assert
            _eventsRepositoryMock.Verify(m => m.AddEventAsync(eventToDatabase), Times.Once);

        }


        [Fact]
        public async Task GetEventByIdAsync_ShouldReturnEventDto_CheckValuesGettingFields()
        {
            // Arrange
            int eventId = 1;
            int loggedUserId = 1;
            var eventFromDatabase = new Event { EventId = 1, AdministratorId = 1 };

            _eventsRepositoryMock.Setup(repo => repo.GetEventByIdAsync(eventId)).ReturnsAsync(eventFromDatabase);
             
            _mapperMock.Setup(mapper => mapper.Map<EventDto>(eventFromDatabase)).Returns(new EventDto { Id = eventFromDatabase.EventId, AdministratorId=eventFromDatabase.AdministratorId });
            _eventsRepositoryMock.Setup(repo => repo.CheckIfLoggedUserIsParticipantAsync(loggedUserId, eventId)).ReturnsAsync(true);
            // Act
            var result = await _eventService.GetEventByIdAsync(eventId, loggedUserId);

            // Assert
            result.Should().NotBeNull(); 
            result.Id.Should().Be(eventId); 
            result.AdministratorId.Should().Be(loggedUserId);
            result.CanLoggedUserDelete.Should().BeTrue();   
            result.CanLoggedUserEdit.Should().BeTrue();
            result.Name.Should().BeNull();
            result.Description.Should().BeNull();
            result.IsLoggedUserParticipant.Should().BeTrue();   

        }

    }
}
