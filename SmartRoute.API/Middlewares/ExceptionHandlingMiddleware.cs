using FluentValidation;
using System.Net;
using System.Text.Json;
using System.Linq;

namespace SmartRoute.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var isValidation = ex is ValidationException ve;
            context.Response.StatusCode = isValidation
                ? StatusCodes.Status400BadRequest
                : StatusCodes.Status500InternalServerError;

            var response = new
            {
                success = false,
                message = isValidation ? "Validation failed" : "An unexpected error occurred",
                details = isValidation ? null : ex.Message,
                errors = isValidation
                    ? ((ValidationException)ex).Errors.Select(e => new { field = e.PropertyName, error = e.ErrorMessage })
                    : null
            };

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
