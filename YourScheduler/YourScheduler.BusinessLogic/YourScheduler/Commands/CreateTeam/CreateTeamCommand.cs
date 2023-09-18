using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.YourScheduler.Commands.CreateCarWorkshop
{
   public class CreateTeamCommand:TeamDto,IRequest
    {
    }
}
