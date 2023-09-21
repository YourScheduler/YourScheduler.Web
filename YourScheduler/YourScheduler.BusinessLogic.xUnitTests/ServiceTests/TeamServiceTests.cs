//using AutoMapper;
//using Moq;
//using Xunit;
//using YourScheduler.BusinessLogic.Models.DTOs;
//using YourScheduler.Infrastructure.Entities;
//using YourScheduler.Infrastructure.Repositories.Interfaces;
//using TeamService = YourScheduler.BusinessLogic.Services.TeamService;
//namespace YourScheduler.BusinessLogic.xUnitTests.ServiceTests
//{
//    public class TeamServiceTests
//    {
//        private readonly Mock<ITeamsRepository> _teamsRepositoryMock;
//        private readonly Mock<IMapper> _mapperMock;
//        private readonly TeamService _teamService;

//        public TeamServiceTests()
//        {
//            _teamsRepositoryMock = new Mock<ITeamsRepository>();
//            _mapperMock = new Mock<IMapper>();
//            _teamService = new TeamService(_teamsRepositoryMock.Object, _mapperMock.Object);
//        }

//        [Fact]
//        public async Task AddTeamAsync_ValidTeamDto_CallsRepositoryAddTeamAsync()
//        {
//            // Arrange
//            var teamDto = new TeamDto();
//            var teamToDatabase = new Team();
//            _mapperMock.Setup(m => m.Map<Team>(teamDto)).Returns(teamToDatabase);

//            // Act
//            await _teamService.AddTeamAsync(teamDto);

//            // Assert
//            _teamsRepositoryMock.Verify(m => m.AddTeamAsync(teamToDatabase), Times.Once);
            
//        }

    
//        [Fact]
//        public async Task GetAvailableTeamsAsync_NoSearchString_ReturnsAllTeams()
//        {
//            // Arrange
//            var loggedUserId = 1;
//            var searchString = string.Empty;
//            var teamsFromDatabase = new List<Team>
//        {
//            new Team { TeamId = 1, Name = "Team 1", AdministratorId = 1 },
//            new Team { TeamId = 2, Name = "Team 2", AdministratorId = 2 },
//            new Team {TeamId = 3, Name = "Team 3", AdministratorId = 1 }
//        };
//            var teamDtos = new List<TeamDto>
//        {
//            new TeamDto { Id = 1, Name = "Team 1" },
//            new TeamDto { Id = 2, Name = "Team 2" },
//            new TeamDto { Id = 3, Name = "Team 3" }
//        };
//            _teamsRepositoryMock.Setup(m => m.GetAllExistedTeamsAsync()).ReturnsAsync(teamsFromDatabase);
//            _mapperMock.Setup(m => m.Map<TeamDto>(It.IsAny<Team>()))
//                .Returns((Team t) => teamDtos.FirstOrDefault(dto => dto.Id == t.TeamId));

//            // Act
//            var result = await _teamService.GetAvailableTeamsAsync(loggedUserId, searchString);

//            // Assert
//            Assert.Equal(3, result.Count);
//            Assert.Equal("Team 1", result[0].Name);
//            Assert.True(result[0].CanLoggedUserDelete);
//            Assert.True(result[0].CanLoggedUserEdit);
//            Assert.False(result[0].IsLoggedUserParticipant);
//            Assert.Equal("Team 2", result[1].Name);
//            Assert.False(result[1].CanLoggedUserDelete);
//            Assert.False(result[1].CanLoggedUserEdit);
//            Assert.False(result[1].IsLoggedUserParticipant);
//            Assert.Equal("Team 3", result[2].Name);
//            Assert.True(result[2].CanLoggedUserDelete);
//            Assert.True(result[2].CanLoggedUserEdit);
//            Assert.False(result[2].IsLoggedUserParticipant);
//        }

       
        
//    }
//}
