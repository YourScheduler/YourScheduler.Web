using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class EventDto
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Pole 'Nazwa wydarzenia' jest obowiązkowe")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Pole 'Opis wydarzenia' jest obowiązkowe")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Pole 'Data' jest obowiązkowe")]
    public DateTime Date { get; set; }

    public bool Isopen { get; set; } = default!;

    public int AdministratorId { get; set; }

    public bool CanLoggedUserEdit { get; set; } = false;

    public bool CanLoggedUserDelete { get; set; } = false;

    public bool IsLoggedUserParticipant { get; set; } = false;

    public string? PicturePath { get; set; }

    public IFormFile? ImageFile { get; set; }
}
