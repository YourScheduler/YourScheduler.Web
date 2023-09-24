using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace YourScheduler.WebApplication.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
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

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                error.Status = (int)HttpStatusCode.InternalServerError;
                error.Type = "Server error";
                error.Title = "Server error";
                error.Detail = $"An internal server error has occured {exception.Message}";
            
            string json = JsonSerializer.Serialize(error);

            //if (exception is customException)
            //{
            //logic
            //}

            return context.Response.WriteAsync(json);

            
        }
    }
}
