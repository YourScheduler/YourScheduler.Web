using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourScheduler.BusinessLogic.Features.Commands.TeamCommands.AddTeamForUserCommand;
using YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetAvailableTeamsQuery;
using YourScheduler.BusinessLogic.Features.Queries.TeamQueries.GetTeamByIdQuery;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.BusinessLogic.Services.Interfaces;

namespace YourScheduler.WebApplication.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHost;
        private readonly IMediator _mediator;

        public TeamController(IWebHostEnvironment webHost, ITeamService teamService, IUserService userService, IMediator mediator)
        {
            _webHost = webHost;
            _teamService = teamService;
            _userService = userService;
            _mediator = mediator;
        }

        [Authorize]
        public async Task<ActionResult> GetAllTeams(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            //var viewModel = await _teamService.GetAvailableTeamsAsync(loggedUserId, searchString);
            var viewModel = await _mediator.Send(new GetAvailableTeamsRequest
            {
                LoggedUserId = loggedUserId,
                SearchString = searchString
            });


            if (String.IsNullOrEmpty(searchString))
            {
                return View(viewModel);
            }
            else
            {
                var allTeams2 = viewModel.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                return View(allTeams2);
            }
        }

        public async Task<ActionResult> DetailsAllTeams(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            //var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            var model = await _mediator.Send(new GetTeamByIdRequest
            {
                Id = id,
                LoggedUserId = loggedUserId
            });
            return View(model);
        }
        public async Task<ActionResult> DetailsUserTeams(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            //var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            var model = await _mediator.Send(new GetTeamByIdRequest
            {
                Id = id,
                LoggedUserId = loggedUserId
            });
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(TeamDto model)
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
                        model.PicturePath = "/Pictures/" + "defaultTeam.jpg";
                    }
                    model.AdministratorId = loggedUserId;

                    //await _teamService.AddTeamAsync(model);
                    await _mediator.Send(model);
                    //TODO - move out of controller
                }
                return RedirectToAction("GetAllTeams", "Team");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            if (model.AdministratorId == loggedUserId)
            {
                return View(model);
            }
            else
            {
                return View("EditError");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, TeamDto model)
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

            var userName = HttpContext.User.Identity.GetUserName();
            var user = _userService.GetUserByEmail(userName);
            model.AdministratorId = user.Id;
            try
            {
                await _teamService.UpdateTeamAsync(model);
                return RedirectToAction("GetAllTeams");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            if (model.AdministratorId == loggedUserId)
            {
                return View(model);
            }
            else
            {
                return View("DeleteError");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, TeamDto model)
        {
            try
            {
                await _teamService.DeleteTeamAsync(id);
                return RedirectToAction("GetAllTeams");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteFromCalendar(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFromCalendar(int id, TeamDto model)
        {
            try
            {
                var userId = int.Parse(User.Identity.GetUserId());
                await _teamService.DeleteTeamFromCalendarAsync(id, userId);
                return RedirectToAction("GetUserTeams");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetUserTeams(string searchString)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            var model = await _teamService.GetMyTeamsAsync(loggedUserId, searchString);
            return View(model);
        }

        [Route("addthisteam/{id:int}")]
        public async Task<ActionResult> AddThisTeam(int id)
        {
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            //var model = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            var model = await _mediator.Send(new GetTeamByIdRequest
            {
                Id = id,
                LoggedUserId = loggedUserId
            });

            return View(model);
        }

        [HttpPost]
        [Route("addthisteam/{id:int}")]
        public async Task<ActionResult> AddThisTeam(TeamDto model)
        {
            try
            {
                var userId = int.Parse(User.Identity.GetUserId());
                //await _teamService.AddTeamForUserAsync(userId, model.Id);
                await _mediator.Send(new AddTeamForUserRequest
                {
                    ApplicationUserId = userId,
                    TeamId = model.Id
                });
                return RedirectToAction(nameof(GetAllTeams));
            }
            catch (Exception)
            {
                return View("AddThisTeamError");
            }
        }

        [Route("teammembers/{id:int}")]
        public async Task<ActionResult> TeamMembers(int id)
        {
            TeamMembersDto teamMembersDto = new TeamMembersDto();
            var loggedUserId = int.Parse(User.Identity.GetUserId());
            //var modelTeam = await _teamService.GetTeamByIdAsync(id, loggedUserId);
            var modelTeam = await _mediator.Send(new GetTeamByIdRequest
            {
                Id = id,
                LoggedUserId = loggedUserId
            });
            teamMembersDto.Name = modelTeam.Name;
            teamMembersDto.Description = modelTeam.Description;
            teamMembersDto.TeamUsers = await _teamService.GetUsersForTeamAsync(id);
            return View(teamMembersDto);
        }
    }
}
