using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace YourScheduler.WebApplication.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync (context, ex);
                
            }
        }
        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            ProblemDetails error = new ProblemDetails();

            if (exception is NullReferenceException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                error.Status = (int)HttpStatusCode.InternalServerError;
                error.Type = "Server error";
                error.Title = "Server error";
                error.Detail = "An internal server error has occured";
            }
            
            string json = JsonSerializer.Serialize(error);

            return context.Response.WriteAsync(json);

            
        }
    }
}
