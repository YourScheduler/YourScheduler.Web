using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using YourScheduler.Infrastructure.CustomExceptions;

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
            catch (CustomException cex)
            {
                _logger.LogError(cex, cex.ProblemDetails.Detail);
                await HandleCustomExceptionAsync(context, cex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            };
        }
        public async Task HandleCustomExceptionAsync(HttpContext context, CustomException customException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            var stackTrace = new StackTrace(customException).GetFrame(0);
            customException.ProblemDetails.Instance = $"Declaring Method: {stackTrace?.GetMethod()?.DeclaringType?.Name}" ?? $"Declaring Method could not be found";

            string json = JsonSerializer.Serialize(customException.ProblemDetails);

            await context.Response.WriteAsync(json);
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            ProblemDetails error = new ProblemDetails();

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            error.Status = (int)HttpStatusCode.InternalServerError;
            error.Type = "Server error";
            error.Title = "Server error";
            error.Detail = $"An internal server error has occured {exception.Message}";

            string json = JsonSerializer.Serialize(error);

            await context.Response.WriteAsync(json);

        }
    }
}