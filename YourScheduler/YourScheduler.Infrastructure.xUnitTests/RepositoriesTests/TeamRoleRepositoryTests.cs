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
                    TeamRoleFlags = new TeamRoleFlags
                    {
                        TeamRoleId = 1,
                        CanAddTeamEvent = false,
                        CanAddTeamMember = false,
                        CanAddTeamRole = false,
                        CanEditDescription= false,
                        CanEditRoleFlags = false,
                        CanEditTeamEvent = false,
                        CanEditTeamMessage = false,
                        CanRemoveTeamMember = false,
                        CanEditTeamName = false,
                        CanEditTeamPhoto = false,
                        CanEditTeamRole = false,
                        CanRemoveTeamEvent = false,
                        CanRemoveTeamRole = false,
                        CanSendEmailToTeam = false
                    }
                },

                new TeamRole
                {
                    TeamRoleId = 2,
                    Name = "Admin",
                    TeamRoleFlags = new TeamRoleFlags
                    {
                        TeamRoleId = 2,
                        CanAddTeamEvent = true,
                        CanAddTeamMember = true,
                        CanAddTeamRole = true,
                        CanEditDescription= true,
                        CanEditRoleFlags = true,
                        CanEditTeamEvent = true,
                        CanEditTeamMessage = true,
                        CanRemoveTeamMember = true,
                        CanEditTeamName = true,
                        CanEditTeamPhoto = true,
                        CanEditTeamRole = true,
                        CanRemoveTeamEvent = true,
                        CanRemoveTeamRole = true,
                        CanSendEmailToTeam = true
                    }
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
                Name = "Moderator",
                TeamRoleFlags = new TeamRoleFlags
                {
                    TeamRoleId = 3,
                    CanAddTeamEvent = false,
                    CanAddTeamMember = true,
                    CanAddTeamRole = false,
                    CanEditDescription = false,
                    CanEditRoleFlags = false,
                    CanEditTeamEvent = false,
                    CanEditTeamMessage = false,
                    CanRemoveTeamMember = true,
                    CanEditTeamName = false,
                    CanEditTeamPhoto = false,
                    CanEditTeamRole = false,
                    CanRemoveTeamEvent = false,
                    CanRemoveTeamRole = false,
                    CanSendEmailToTeam = false
                }
            };

            context.Teams.Add(testTeam);
            context.SaveChanges();

            await repository.AddTeamRoleAsync(newRole, 1);

            var teamWithRoles = context.Teams.First(t => t.TeamId == testTeam.TeamId);

            teamWithRoles.TeamRoles.Count.Should().Be(3);
            teamWithRoles.TeamRoles.First(t => t.TeamRoleId == newRole.TeamRoleId).Name.Should().Be("Moderator");
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
                TeamRoleFlags = new TeamRoleFlags
                {
                    TeamRoleId = 1,
                    CanAddTeamEvent = false,
                    CanAddTeamMember = false,
                    CanAddTeamRole = false,
                    CanEditDescription = false,
                    CanEditRoleFlags = false,
                    CanEditTeamEvent = false,
                    CanEditTeamMessage = false,
                    CanRemoveTeamMember = false,
                    CanEditTeamName = false,
                    CanEditTeamPhoto = false,
                    CanEditTeamRole = false,
                    CanRemoveTeamEvent = false,
                    CanRemoveTeamRole = false,
                    CanSendEmailToTeam = false
                }
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
