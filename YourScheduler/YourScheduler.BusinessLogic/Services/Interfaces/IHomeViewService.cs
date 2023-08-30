using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Services.Interfaces
{
    public interface IHomeViewService
    {
        public HomeView GetHomeView(int id);  
    }
}
