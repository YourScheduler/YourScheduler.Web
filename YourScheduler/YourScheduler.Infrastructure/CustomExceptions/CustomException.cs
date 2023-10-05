using Microsoft.AspNetCore.Mvc;

namespace YourScheduler.Infrastructure.CustomExceptions
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
