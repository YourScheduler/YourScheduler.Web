using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace YourScheduler.Infrastructure.CustomExceptions
{
    public class RegisterException : CustomException
    {
        public RegisterException(string message) : base(new ProblemDetails
        {
            Status = (int) HttpStatusCode.BadRequest,
            Type = "Bad Request",
            Title = "Couldn't register user",
            Detail = message
        })
        {}
    }
}
