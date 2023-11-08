using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace YourScheduler.Infrastructure.CustomExceptions
{
    public class EventNotFoundException : CustomException
    {
        public EventNotFoundException() : base(new ProblemDetails
        {
            Status = (int)HttpStatusCode.NotFound,
            Type = "Could not find entity",
            Title = "Could not find Event",
            Detail = "The requested event with provided Id does'nt exist in the database"
        })
        { }
    }
}
