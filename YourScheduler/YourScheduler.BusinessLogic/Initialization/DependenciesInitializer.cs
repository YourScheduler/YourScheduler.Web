using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.BusinessLogic.Services.Interfaces;
using YourScheduler.BusinessLogic.YourScheduler.Commands.CreateCarWorkshop;

namespace YourScheduler.BusinessLogic.Initialization
{
    public static class DependenciesInitializer
    {
        public static void AddBusinessLogicDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IEventService, EventService>();
            // serviceCollection.AddScoped<ITeamService, TeamService>();
            serviceCollection.AddMediatR(typeof(CreateTeamCommand));
            serviceCollection.AddScoped<IHomeViewService, HomeViewService>();
            serviceCollection.AddSingleton<IEmailService, EmailService>();         

        }
    }
}
