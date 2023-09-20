using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Initialization
{
    public static class DependenciesInitializer
    {
        public static void AddBusinessLogicDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IEventService, EventService>();
            serviceCollection.AddScoped<ITeamService, TeamService>();
            serviceCollection.AddScoped<IHomeViewService, HomeViewService>();
            serviceCollection.AddSingleton<IEmailService, EmailService>();
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}
