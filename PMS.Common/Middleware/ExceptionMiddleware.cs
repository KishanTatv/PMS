using Microsoft.AspNetCore.Http;
using PMS.Entity;
using System.Net;
using System.Text.Json;

namespace PMS.Common.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;

        public ExceptionMiddleware(RequestDelegate nextMiddleware)
        {
            _nextMiddleware = nextMiddleware;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _nextMiddleware(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                var response = new ApiResponse<string>()
                {
                    Result = false,
                    Data = string.Empty,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occurred. Please try again later."
                };
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
