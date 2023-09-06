using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class TeamDto
{
    public int TeamId { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa zespołu' jest obowiązkowe")]
    public string Name { get; set; } = default!;
    [Required(ErrorMessage = "Pole 'Opis zespołu' jest obowiązkowe")]
    public string? Description { get; set; }

    public int Creator { get; set; } = default!;

    public string? Message { get; set; }

    public string? PicturePath { get; set; }

    public IFormFile? ImageFile { get; set; }

    
}
