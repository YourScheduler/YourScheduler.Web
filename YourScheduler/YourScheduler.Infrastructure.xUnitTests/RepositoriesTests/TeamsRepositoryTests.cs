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
       
        [Fact]
        public async Task TeamRepository_AddTeam_ReturnAddedTeamById()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context, loggerMock.Object);
            Team team = new Team
            {
                TeamId=1,
                Name="Piłkarze",
                Description="Bardzo lubimy grać w piłkę nożną",
                PicturePath = "/Picures/Pilkarz.jpg"
            };
          
            //Act
            await repository.AddTeamAsync(team);
            
            var teamReturned = await repository.GetTeamByIdAsync(1);

            //Assert
            teamReturned.TeamId.Should().Be(1);  
                     
            
        }

        [Fact]
        public async Task AddTeam_CheckIfListTeamsIsNotEmpty()
        {
            //Assign
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context, loggerMock.Object);
            Team team = new Team
            {
                Name = "Piłkarze",
                Description = "Bardzo lubimy grać w piłkę nożną",
                PicturePath="/Picures/Pilkarz.jpg"
            };


            // Act
            await repository.AddTeamAsync(team);
            var teamReturned = await repository.GetAllExistedTeamsAsync();  

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
            Team team = new Team
            {
                Name = "Sangria",
                Description = "Test",
                PicturePath = "/Picures/Pilkarz.jpg"
            };

            //Act
            await repository.AddTeamAsync(team);

            //Assert
            var addedTeam = await context.Teams.SingleOrDefaultAsync(t => t.TeamId == team.TeamId);

            addedTeam.Should().NotBeNull();
            addedTeam.Name.Should().Be(team.Name);
            addedTeam.Description.Should().Be(team.Description);
            addedTeam.PicturePath.Should().Be(team.PicturePath);
        }

        [Fact]
        public async Task TeamRepository_GetTeamById_ReturnAddedTeamById()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context,loggerMock.Object);
            Team team = new Team
            {
                Name = "Sangria",
                Description = "Test",
                PicturePath = "/Picures/Pilkarz.jpg"
            };

            context.Teams.Add(team);

            await context.SaveChangesAsync();

            //Act
            var returnedTeam = await repository.GetTeamByIdAsync(team.TeamId);

            //Assert
            returnedTeam.Should().NotBeNull();
            returnedTeam.Name.Should().Be(team.Name);
            returnedTeam.Description.Should().Be(team.Description);
            returnedTeam.PicturePath.Should().Be(team.PicturePath);
        }

        [Fact]
        public async Task TeamRepository_DeleteTeamById()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context,loggerMock.Object);
            Team team = new Team
            {
                TeamId=1,
                Name = "Sangria",
                Description = "Test",
                PicturePath = "/Picures/Pilkarz.jpg"
            };

            context.Teams.Add(team);

            await context.SaveChangesAsync();

            //Act
            await repository.DeleteTeamByIdAsync(1);



           // Assert
            var deletedTeam = await repository.GetAllExistedTeamsAsync();
            foreach (var item in deletedTeam)
            {
                deletedTeam.Should().BeNull();
            }
           
        }

        [Fact]
        public async Task TeamRepository_UpdateTeam_ReturnUpdatedTeam()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamsRepository(context,loggerMock.Object);
            Team team = new Team
            {
                TeamId=1,
                Name = "Sangria",
                Description = "Test",
                PicturePath = "/Picures/Pilkarz.jpg"
            };

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
            Team team = new Team
            {
                Name = "Sangria",
                Description = "Test",
                PicturePath = "/Picures/Pilkarz.jpg"
            };

            //Act
            await repository.AddTeamAsync(team);

            //Assert
            var addedTeam = await context.Teams.SingleOrDefaultAsync(t => t.TeamId == team.TeamId);

            addedTeam.Should().NotBeNull();
            addedTeam.Name.Should().Be(team.Name);
            addedTeam.Description.Should().Be(team.Description);
            addedTeam.PicturePath.Should().Be(team.PicturePath);

        }

    }
}
