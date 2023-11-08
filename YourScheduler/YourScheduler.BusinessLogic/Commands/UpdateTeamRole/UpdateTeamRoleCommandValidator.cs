using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.Infrastructure.Repositories.Interfaces;

namespace YourScheduler.BusinessLogic.Commands.UpdateTeamRole
{
   public class UpdateTeamRoleCommandValidator:AbstractValidator<UpdateTeamRoleCommand>
    {
        public UpdateTeamRoleCommandValidator(ITeamRoleRepository teamRoleRepository)
        {
            RuleFor(c => c.TeamRoleDto.Name).NotEmpty().MinimumLength(2).WithMessage("Name should have at least 2 characters")
              .MinimumLength(20).WithMessage("Name should have maximum of 20 characters");
        }
    }
}
