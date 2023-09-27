using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.CreateTeam
{
    public class CreateTeamCommandValidator:AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator(ITeamsRepository teamsRepository)
        {
            RuleFor(c => c.TeamDto.Name).NotEmpty().MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MinimumLength(20).WithMessage("Name should have maximum of 20 characters");
            RuleFor(c => c.TeamDto.Description).NotEmpty().WithMessage("Please enter description");
            
        }
    }
}
