using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class TeamDto : IRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa zespołu' jest obowiązkowe")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Pole 'Opis zespołu' jest obowiązkowe")]
    public string Description { get; set; } = null!;

    public int AdministratorId { get; set; }

    public bool CanLoggedUserEdit { get; set; } = false;

    public bool CanLoggedUserDelete { get; set; } = false;

    public bool IsLoggedUserParticipant { get; set; } = false;

    public string PicturePath { get; set; }

    public IFormFile ImageFile { get; set; }

    
}
