using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace YourScheduler.Infrastructure.CustomExceptions
{
    public class UserByEmailNotFoundException : CustomException
    {
        public UserByEmailNotFoundException() : base(new ProblemDetails
        {
            Status = (int)HttpStatusCode.NotFound,
            Type = "Could not find entity",
            Title = "Could not find User",
            Detail = "The requested user with provided email does'nt exist in the database"
        })
        {}
    }
}
