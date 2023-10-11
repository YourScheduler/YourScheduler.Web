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
        private readonly TeamRole userTeamRole = new()
        {
            TeamId = 1,
            TeamRoleId = 1,
            Name = "User",
            TeamRoleFlags = new TeamRoleFlags
            {
                TeamRoleFlagsId = 1,
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
                CanSendEmailToTeam = false,
                CanViewContent = true
            }
        };
        private readonly TeamRole adminTeamRole = new()
        {
            TeamRoleId = 2,
            TeamId = 1,
            Name = "Admin",
            TeamRoleFlags = new TeamRoleFlags
            {
                TeamRoleFlagsId = 2,
                CanAddTeamEvent = true,
                CanAddTeamMember = true,
                CanAddTeamRole = true,
                CanEditDescription = true,
                CanEditRoleFlags = true,
                CanEditTeamEvent = true,
                CanEditTeamMessage = true,
                CanRemoveTeamMember = true,
                CanEditTeamName = true,
                CanEditTeamPhoto = true,
                CanEditTeamRole = true,
                CanRemoveTeamEvent = true,
                CanRemoveTeamRole = true,
                CanSendEmailToTeam = true,
                CanViewContent = true
            }
        };

        [Fact]
        public async Task GetAllTeamRolesForTeamQueryable_ShouldReturnListWithTwoItems()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var teamRoleRepository = new TeamRoleRepository(context, loggerMock.Object);

            await context.TeamRoles.AddRangeAsync(new List<TeamRole>() { userTeamRole, adminTeamRole });
            await context.SaveChangesAsync();

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
                    TeamRoleFlagsId = 3,
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

            await context.TeamRoles.AddRangeAsync(new List<TeamRole>() { userTeamRole, adminTeamRole });
            context.SaveChanges();

            await repository.AddTeamRoleAsync(newRole);

            context.TeamRoles.Count().Should().Be(3);
            context.TeamRoles.First(t => t.TeamRoleId == newRole.TeamRoleId).Name.Should().Be("Moderator");
        }
        [Fact]
        public async Task UpdateTeamRoleAsync_ShouldSucceed()
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamRoleRepository(context, loggerMock.Object);

            await context.TeamRoles.AddRangeAsync(new List<TeamRole>() { userTeamRole, adminTeamRole });
            context.SaveChanges();

            context.ChangeTracker.Clear();

            var roleToUpdate = new TeamRole
            {
                TeamId = 1,
                TeamRoleId = 1,
                Name = "Basic User",
                TeamRoleFlags = new TeamRoleFlags
                {
                    TeamRoleFlagsId = 1,
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

            await repository.UpdateTeamRoleAsync(roleToUpdate);
            context.TeamRoles.First(t => t.TeamRoleId == roleToUpdate.TeamRoleId).Name.Should().Be(roleToUpdate.Name);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task RemoveTeamRoleByIdAsync_ShouldSucceed(int teamRoleId)
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamRoleRepository(context, loggerMock.Object);

            await context.TeamRoles.AddRangeAsync(new List<TeamRole>() { userTeamRole, adminTeamRole });
            context.SaveChanges();

            var initialCount = context.TeamRoles.Count();

            await repository.RemoveTeamRoleByIdAsync(teamRoleId);

            context.TeamRoles.Count().Should().Be(initialCount - 1);

        }
        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(12)]
        public async Task RemoveTeamRoleByIdAsync_ShouldThrowException(int teamRoleId)
        {
            var context = ContextGenerator.Generate();
            var loggerMock = new Mock<ILogger<TeamsRepository>>();
            var repository = new TeamRoleRepository(context, loggerMock.Object);

            await context.TeamRoles.AddRangeAsync(new List<TeamRole>() { userTeamRole, adminTeamRole });
            context.SaveChanges();

            Func<Task> removeMethod = async () => await repository.RemoveTeamRoleByIdAsync(teamRoleId);

            await removeMethod.Should().ThrowAsync<ArgumentNullException>();

        }
    }
}
