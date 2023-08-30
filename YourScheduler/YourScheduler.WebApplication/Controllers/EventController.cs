using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.WebApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IEventService _eventService;
       
        public EventController(IWebHostEnvironment webHost,IEventService eventService)
        {
            _webHost = webHost;
            _eventService = eventService;
        }

        [Authorize]
        public async Task<ActionResult> GetAllEvents(string searchString)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetAvailableEventsAsync(loggedUserId, searchString);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetUserEvents(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _eventService.GetMyEventsAsync(loggedUserId, searchString);
            return View(model);
        }

        [Route("addthisevent/{id:int}")]
        public async Task<ActionResult> AddThisEvent(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
            return View(model);
        }

        [HttpPost]
        [Route("addthisevent/{id:int}")]
        public async Task<ActionResult> AddThisEvent(EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var eventToAddId = model.Id;
                await _eventService.AddEventForUserAsync(loggedUserId, eventToAddId);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> DetailsAllEvents(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
                return View(model);
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> DetailsUserEvents(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
            
                if (model != null)
                {
                    //TODO - move out of controller
                    if (!Directory.Exists("wwwroot/Pictures"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory("wwwroot/Pictures");
                    }
                    if (model.ImageFile != null)
                    {
                        var saveimg = Path.Combine(_webHost.WebRootPath, "Pictures", model.ImageFile.FileName);
                        string imgext = Path.GetExtension(model.ImageFile.FileName);
                        if (imgext == ".jpg" || imgext == ".png")
                        {
                            using (var uploading = new FileStream(saveimg, FileMode.Create))
                            {
                                await model.ImageFile.CopyToAsync(uploading);
                            }
                        }
                        model.PicturePath = "/Pictures/" + model.ImageFile.FileName;
                    }
                    else
                    {
                        model.PicturePath = "/Pictures/" + "defaultEvent.jpg";
                    }
                    await _eventService.AddEventAsync(model, loggedUserId);
                    //TODO - move out of controller
                }
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, EventDto model)
        {
            try
            {
                //TODO - move out of controller
                if (!Directory.Exists("wwwroot/Pictures"))
                {
                    DirectoryInfo di = Directory.CreateDirectory("wwwroot/Pictures");
                }
                if (model.ImageFile != null)
                {
                    var saveimg = Path.Combine(_webHost.WebRootPath, "Pictures", model.ImageFile.FileName);
                    string imgext = Path.GetExtension(model.ImageFile.FileName);
                    if (imgext == ".jpg" || imgext == ".png")
                    {
                        using (var uploading = new FileStream(saveimg, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(uploading);
                        }
                    }
                    model.PicturePath = "/Pictures/" + model.ImageFile.FileName;
                }
                //TODO - move out of controller

                var loggedUserId = int.Parse(User.Identity.GetUserId());
                await _eventService.UpdateEventAsync(model, loggedUserId);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, EventDto model)
        {
            try
            {
                await _eventService.DeleteEventAsync(id);
                return RedirectToAction(nameof(GetAllEvents));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteFromCalendar(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var model = await _eventService.GetEventByIdAsync(id, loggedUserId);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFromCalendar(int id, EventDto model)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                await _eventService.DeleteEventFromCalendarAsync(id, loggedUserId);
                return RedirectToAction(nameof(GetUserEvents));
            }
            catch
            {
                return View();
            }
        }

        [Route("eventmembers/{id:int}")]
        public async Task<ActionResult> EventMembers(int id)
        {
            try
            {
                var loggedUserId = int.Parse(User.Identity.GetUserId());
                var eventMembersDto = await _eventService.GetEventMembersDtoAsync(id, loggedUserId);
                return View(eventMembersDto);
            }
            catch
            {
                return View();
            }
        }
    }
}
