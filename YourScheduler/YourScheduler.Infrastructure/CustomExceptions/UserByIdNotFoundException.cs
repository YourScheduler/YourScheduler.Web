using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace YourScheduler.Infrastructure.CustomExceptions
{
    public class UserByIdNotFoundException : CustomException
    {
        public UserByIdNotFoundException() : base(new ProblemDetails
        {
            Status = (int)HttpStatusCode.NotFound,
            Type = "Could not find entity",
            Title = "Could not find User",
            Detail = "The requested user with provided Id does'nt exist in the database"
        })
        {}
    }
}
