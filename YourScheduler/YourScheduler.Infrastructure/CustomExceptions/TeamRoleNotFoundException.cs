using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace YourScheduler.Infrastructure.CustomExceptions
{
    public class TeamRoleNotFoundException : CustomException
    {
        public TeamRoleNotFoundException() : base(new ProblemDetails
        {
            Status = (int)HttpStatusCode.NotFound,
            Type = "Could not find entity",
            Title = "Could not find TeamRole",
            Detail = "The requested TeamRole with provided Id does'nt exist in the database"
        })
        { }
    }
}
