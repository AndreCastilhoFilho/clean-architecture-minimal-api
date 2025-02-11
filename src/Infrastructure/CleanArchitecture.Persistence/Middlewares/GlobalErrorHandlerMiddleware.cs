using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlerMiddleware> _logger;

        public GlobalErrorHandlerMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)  // Handle FluentValidation errors
            {
                _logger.LogWarning("Validation error: {Errors}", ex.Errors);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var errors = ex.Errors.ToDictionary(f => f.PropertyName, f => f.ErrorMessage);
                var response = new { Message = "Validation failed", Errors = errors };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception ex)  // Handle all other exceptions
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new { Message = "An unexpected error occurred", Details = ex.Message };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
