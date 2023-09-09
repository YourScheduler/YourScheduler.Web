using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using YourScheduler.Infrastructure.Entities;
using YourScheduler.Infrastructure.Repositories;

namespace YourScheduler.Infrastructure.xUnitTests.RepositoriesTests
{
    public class TeamRoleRepositoryTests
    {
        private readonly Team testTeam = new()
        {
            TeamId = 1,
            Name = "Amazing team",
            Description = "We be ballin!",
            Creator = new ApplicationUser() { Name = "Kamil" }.Name,
            TeamRoles = new TeamRole[]
            {
                new TeamRole
                {
                    TeamRoleId = 1,
                    Name = "User",
                    TeamRoleFlags = new TeamRoleFlags(1, false, false, false, false, false, false, false, false, false, false, false, false, false, false)
                },
                new TeamRole
                {
                    TeamRoleId = 2,
                    Name = "Admin",
                    TeamRoleFlags = new TeamRoleFlags(2, true, true, true, true, true, true, true, true, true, true, true, true, true, true)
                }
            }
        };

        [Fact]
        public void GetAllTeamRolesForTeamQueryable_ShouldReturnListWithTwoItems()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var teamRoleRepository = new TeamRoleRepository(context, loggerMock.Object);

            context.Teams.Add(testTeam);
            context.SaveChanges();

            var returnedTeamRoles = teamRoleRepository.GetAllTeamRolesForTeamQueryable(1).ToList();

            returnedTeamRoles.Should().NotBeEmpty();
            returnedTeamRoles.Should().HaveCount(2);
        }

        [Fact]
        public async Task AddTeamRoleAsync_ShouldAddNewRole()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamRoleRepository(context, loggerMock.Object);
            var newRole = new TeamRole
            {
                TeamRoleId = 3,
                Name = "VIP",
                TeamRoleFlags = new TeamRoleFlags(3, true, true, false, false, false, false, true, true, true, false, true, true, true, true)
            };

            context.Teams.Add(testTeam);
            context.SaveChanges();

            await repository.AddTeamRoleAsync(newRole, 1);

            var teamWithRoles = context.Teams.First(t => t.TeamId == testTeam.TeamId);

            teamWithRoles.TeamRoles.Count.Should().Be(3);
            teamWithRoles.TeamRoles.First(t => t.TeamRoleId == newRole.TeamRoleId).Name.Should().Be("VIP");
        }
        [Fact]
        public async Task UpdateTeamRoleAsync_ShouldSucceed()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamRoleRepository(context, loggerMock.Object);

            context.Teams.Add(testTeam);
            context.SaveChanges();

            var roleToUpdate = new TeamRole
            {
                TeamRoleId = 1,
                Name = "Basic User",
                TeamRoleFlags = new TeamRoleFlags(1, false, false, false, false, false, false, false, false, false, false, false, false, false, false)
            };

            await repository.UpdateTeamRoleAsync(roleToUpdate, 1);
            Team updatedTeam = context.Teams.First(t => t.TeamId == testTeam.TeamId);
            TeamRole updatedRole = updatedTeam.TeamRoles.First(r => r.TeamRoleId == roleToUpdate.TeamRoleId);

            updatedRole.Name.Should().Be("Basic User");
        }
        [Fact]
        public async Task RemoveTeamRoleByIdAsync_ShouldSucceed()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamRoleRepository(context, loggerMock.Object);

            context.Teams.Add(testTeam);
            context.SaveChanges();

            await repository.RemoveTeamRoleByIdAsync(1, testTeam.TeamId);

            var updatedTeam = context.Teams.First(t => t.TeamId == testTeam.TeamId);

            updatedTeam.TeamRoles.Count.Should().Be(1);
        }
    }
}
