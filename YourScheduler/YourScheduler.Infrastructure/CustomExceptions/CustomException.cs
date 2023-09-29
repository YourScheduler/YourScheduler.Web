using Microsoft.AspNetCore.Mvc;

namespace YourScheduler.WebApplication.CustomExceptions
{
    public abstract class CustomException : Exception
    {
        public ProblemDetails ProblemDetails { get; }

        public CustomException(ProblemDetails problemDetails)
        {
            ProblemDetails = problemDetails;
        }
    }
}
