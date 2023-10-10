using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class TeamDto
{
    public int TeamId { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa zespołu' jest obowiązkowe")]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "Pole 'Opis zespołu' jest obowiązkowe")]
    public string? Description { get; set; }

    public string Creator { get; set; } = default!;

    public string? Message { get; set; }

    public bool IsPrivate { get; set; } = default!;

    public ICollection<TeamRoleDto> TeamRoles { get; set; } = default!;

    public string? PicturePath { get; set; }

    public IFormFile? ImageFile { get; set; }

    
}
