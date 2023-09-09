using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public class TeamsRepositoryTests
    {
        private readonly Team pilkarzeTeam = new()
        {
            TeamId = 1,
            Name = "Piłkarze",
            Description = "Bardzo lubimy grać w piłkę nożną",
            PicturePath = "/Picures/Pilkarz.jpg"
        };
        private readonly Team sangriaTeam = new()
        {
            TeamId = 1,
            Name = "Sangria",
            Description = "Test",
            PicturePath = "/Picures/Pilkarz.jpg"
        };
       
        [Fact]
        public async Task TeamRepository_AddTeam_ReturnAddedTeamById()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context, loggerMock.Object);

          
            //Act
            await repository.AddTeamAsync(pilkarzeTeam);
            
            var teamReturned = await repository.GetTeamByIdAsync(pilkarzeTeam.TeamId);

            //Assert
            teamReturned.TeamId.Should().Be(1);
            teamReturned.Name.Should().Be("Piłkarze");
                     
            
        }

        [Fact]
        public async Task AddTeam_CheckIfListTeamsIsNotEmpty()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context, loggerMock.Object);


            // Act
            await repository.AddTeamAsync(pilkarzeTeam);
            var teamReturned = repository.GetAllExistedTeamsQueryable().ToList();  

            //Assert
            teamReturned.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task TeamRepository_AddTeam_ReturnAddedTeam()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context, loggerMock.Object);

            //Act
            await repository.AddTeamAsync(sangriaTeam);

            //Assert
            var addedTeam = await context.Teams.SingleOrDefaultAsync(t => t.TeamId == sangriaTeam.TeamId);

            addedTeam.Should().NotBeNull();
            addedTeam.Name.Should().Be(sangriaTeam.Name);
            addedTeam.Description.Should().Be(sangriaTeam.Description);
            addedTeam.PicturePath.Should().Be(sangriaTeam.PicturePath);
        }

        [Fact]
        public async Task TeamRepository_GetTeamById_ReturnAddedTeamById()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context,loggerMock.Object);

            context.Teams.Add(sangriaTeam);

            await context.SaveChangesAsync();

            //Act
            var returnedTeam = await repository.GetTeamByIdAsync(sangriaTeam.TeamId);

            //Assert
            returnedTeam.Should().NotBeNull();
            returnedTeam.Name.Should().Be(sangriaTeam.Name);
            returnedTeam.Description.Should().Be(sangriaTeam.Description);
            returnedTeam.PicturePath.Should().Be(sangriaTeam.PicturePath);
        }

        [Fact]
        public async Task TeamRepository_DeleteTeamById()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context,loggerMock.Object);

            context.Teams.Add(sangriaTeam);

            await context.SaveChangesAsync();

            //Act
            await repository.DeleteTeamByIdAsync(1);

           // Assert
            var deletedTeam = repository.GetAllExistedTeamsQueryable().ToList();

            deletedTeam.Count.Should().Be(0);
           
        }

        [Fact]
        public async Task TeamRepository_UpdateTeam_ReturnUpdatedTeam()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context,loggerMock.Object);

            var team = sangriaTeam;

            context.Teams.Add(team);

            await context.SaveChangesAsync();

            const string updatedTeamName = "Dzbanek";

            var updatedTeamDescription = "Pełny";

            team.Name = updatedTeamName;
            team.Description = updatedTeamDescription;

            //Act
            await repository.UpdateTeamAsync(team);

            //Assert
            var updatedTeam = await context.Teams.SingleOrDefaultAsync(t => t.TeamId == team.TeamId);

            updatedTeam.Should().NotBeNull();
            updatedTeam.Name.Should().Be(updatedTeamName);
            updatedTeam.Description.Should().Be(updatedTeamDescription);
        }

        [Fact]
        public async Task TeamRepository_AddTeamForUser_ReturnAddedTeamToUser()
        {
            //Asign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context, loggerMock.Object);


            //Act
            await repository.AddTeamAsync(sangriaTeam);

            //Assert
            var addedTeam = await context.Teams.SingleOrDefaultAsync(t => t.TeamId == sangriaTeam.TeamId);

            addedTeam.Should().NotBeNull();
            addedTeam.Name.Should().Be(sangriaTeam.Name);
            addedTeam.Description.Should().Be(sangriaTeam.Description);
            addedTeam.PicturePath.Should().Be(sangriaTeam.PicturePath);

        }

    }
}
