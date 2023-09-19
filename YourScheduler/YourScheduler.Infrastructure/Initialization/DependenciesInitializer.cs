using Microsoft.Extensions.DependencyInjection;
using YourScheduler.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.Infrastructure.Initialization
{
    public static class DependenciesInitializer
    {

        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
        }
    }
}
