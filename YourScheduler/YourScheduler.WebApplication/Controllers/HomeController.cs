using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.WebApplication.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeViewService _homeViewService; 

        public HomeController(ILogger<HomeController> logger, IHomeViewService homeViewService)
        {
            _logger = logger;
            _homeViewService = homeViewService; 
        }

        public IActionResult Index()
        {
            var model = _homeViewService.GetHomeView(1);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}