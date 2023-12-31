﻿using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace YourScheduler.Infrastructure.CustomExceptions
{
    public class TeamNotFoundException : CustomException
    {
        public TeamNotFoundException() : base(new ProblemDetails
        {
            Status = (int)HttpStatusCode.NotFound,
            Type = "Could not find entity",
            Title = "Could not find Team",
            Detail = "The requested team with provided Id does'nt exist in the database"
        })
        {}
    }
}
