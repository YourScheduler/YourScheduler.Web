using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.CustomExceptions
{
    public class AuthorizationException : CustomException
    {
        public AuthorizationException(string message) : base(new ProblemDetails
        {
            Status = (int)HttpStatusCode.BadRequest,
            Type = "Bad Request",
            Title = "Couldn't authenticate user",
            Detail = message
        })
        {}
    }
}
