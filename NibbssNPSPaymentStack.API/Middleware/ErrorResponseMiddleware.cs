using System.Text.Json;

namespace EasyPay.API.Middleware
{
    public class ErrorResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Run the pipeline (auth, endpoints, etc.)
            await _next(context);

            // After everything finishes, check if we need to write an auth error
            if (context.Response.StatusCode is 401 or 403)
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";

                    var errorMsg = context.Items.TryGetValue("AuthError", out var msg)
                        ? msg?.ToString()
                        : "Authentication failed";

                    var json = JsonSerializer.Serialize(new { error = errorMsg });
                    await context.Response.WriteAsync(json);
                }
            }


        }
    }
}