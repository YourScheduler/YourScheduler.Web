using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

       // private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _signInManager;
        public UserController(IUserService userService)
        {
            _userService = userService;
                   
        }
        // GET: UserController

        [Authorize]
        public  ActionResult Index()
        {
            var userId =int.Parse( HttpContext.User.Identity.GetUserId());


            var model = _userService.GetUserById(userId);
            return View(model);
        }

        // GET: UserController/Details/5
      //  [Route("details/{id:int}")]
        public ActionResult Details()
        {
            return RedirectToAction("Create","Event");
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return RedirectToAction("Create", "Team");
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var model = _userService.GetUserById(id);
            return View(model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Route("edit/{id:int}")]
        public ActionResult Edit(int id, ApplicationUserDto userDto)
        {
            try
            {
                _userService.UpdateUser(userDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error of editing user");
            }
        }

    }
}
