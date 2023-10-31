using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourScheduler.BusinessLogic.Models;

namespace YourScheduler.BusinessLogic.Queries.RefreshUser
{
    public class RefreshUserQuery : IRequest<AuthorizationResponse>
    {
        public string Email { get; }

        public RefreshUserQuery(string email)
        {
            Email = email;
        }
    }
}
