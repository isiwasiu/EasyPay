using global::NibbssNPSPaymentStack.API.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using NibssNPSPaymentStack.Data;
using NibssNPSPaymentStack.Data.Models.Model;
using Org.BouncyCastle.Crypto.Generators;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace NibbssNPSPaymentStack.Business.Services
{

    public class UserRegistrationService
    {
        private readonly NPSDBContext _context; // replace with your DbContext type
        private readonly RequestDelegate _next;

        public UserRegistrationService(NPSDBContext context, IConfiguration configuration, RequestDelegate next )
        {
            _context = context;
            _next = next;
        }



        public async Task InvokeAsync(HttpContext httpContext)
        {
            // 1. Extract the API Key from the Authorization header
            if (!httpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.ContentType = "application/json"; // Set correct header
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Missing Authorization header" }));
                return;
            }

            var authValue = authHeader.ToString();
            if (string.IsNullOrEmpty(authValue) || !authValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Invalid Authorization format. Use Bearer <key>" }));
                return;
            }

            var providedKey = authValue.Substring("Bearer ".Length).Trim();

            // 2. Validate the key against your database table
            var client = await _context.UsersSetup.FirstOrDefaultAsync(x => x.ApiKey == providedKey);

            // 3. Handle invalid key
            if (client == null)
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Invalid Bearer Token Key" }));
                return;
            }

       

       

            if (string.IsNullOrEmpty(providedKey) || providedKey != client.ApiKey)
            {
                httpContext.Response.StatusCode = 401; // or 403
                await httpContext.Response.WriteAsync("{\"error\": \"Invalid API Key\"}");
                return;
            }




            // 4. Check active status & expiry
            if (!client.IsActive)
            {
                httpContext.Response.StatusCode = 403;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = "API Key is deactivated" }));
                return;
            }

            if (client.ExpiredAt.HasValue && client.ExpiredAt.Value < DateTime.UtcNow)
            {
                httpContext.Response.StatusCode = 403;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = "API Key has expired" }));
                return;
            }

            // 5. Store userId for controllers
            httpContext.Items["UserId"] = client.UserId;

            // 6. Call the next middleware
                 await _next(httpContext);
        }

    }
}