using FluentAssertions.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YourScheduler.BusinessLogic.Commands.CreateTeam;
using YourScheduler.BusinessLogic.Services;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.BusinessLogic.Initialization
{
    public static class DependenciesInitializer
    {
        public static void AddBusinessLogicDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTeamCommand).Assembly));
            serviceCollection.AddSingleton<IEmailService, EmailService>();         
        }
    }
}
