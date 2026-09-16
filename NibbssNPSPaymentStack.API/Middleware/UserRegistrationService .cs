using global::NibbssNPSPaymentStack.API.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using NibssNPSPaymentStack.Data;
using Microsoft.AspNetCore.Authorization;
using NibssNPSPaymentStack.Data.Models.Model;
using NPOI.OpenXmlFormats.Dml;
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

namespace EasyPay.API.Middleware
{

    public class UserRegistrationService
    {
        // private readonly NPSDBContext _context; // replace with your DbContext type
        private readonly RequestDelegate _next;
        private static readonly HashSet<string> _whitelistedPaths = new(StringComparer.OrdinalIgnoreCase)
    {
        "/Register",   // adjust to your actual token endpoint
        "/login",      // add any other public endpoints
        "/api/EasyAdmin/AllEndpoints",
        "GetParticipant",
        "Account-Verification",
        "Easy-Pay/Customer-Credit-Transfer",
        "Direct-Credit-Transfer",
        "/pain/008",
        "/pain/001",
        "/pain/002",
        "/acmt/023",
        "/acmt/024"
    };

        public UserRegistrationService(IConfiguration configuration, RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var path = httpContext.Request.Path.Value ?? "";

            // Normalize: trim trailing slash for comparison
            var normalizedPath = path.TrimEnd('/');

            // Check whitelist using normalized path AND both with/without leading slash
            if (IsWhitelisted(normalizedPath))
            {
                await _next(httpContext);
                return;
            }

            var endpoint = httpContext.GetEndpoint();
            var allowAnonymous = endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;

            if (allowAnonymous)
            {
                // Skip API key validation – just continue the pipeline
                await _next(httpContext);
                return;
            }

            var dbContext = httpContext.RequestServices.GetRequiredService<NPSDBContext>();

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
            var apiKey = httpContext.Request.Headers["API-Key"].FirstOrDefault();

            if (string.IsNullOrEmpty(apiKey))
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = "API-Key header is missingy" }));
                return;
            }

            // Trim to be safe
            apiKey = apiKey.Trim();

            // 2. Validate the key against your database table
            var client = await dbContext.UsersSetup.FirstOrDefaultAsync(x => x.ApiKey == apiKey);

            // 3. Handle invalid key
            if (client == null)
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Invalid API Key" }));
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
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = "Client Lincence has expired" }));
                return;
            }

            // 5. Store userId for controllers
            httpContext.Items["UserId"] = client.UserId;

            // 6. Call the next middleware
            await _next(httpContext);
        }

        // Helper: match whitelist with or without leading slash, and allow sub-routes
        private static bool IsWhitelisted(string normalizedPath)
        {
            // Ensure path has leading slash for comparison
            var withSlash = normalizedPath.StartsWith("/") ? normalizedPath : "/" + normalizedPath;

            foreach (var entry in _whitelistedPaths)
            {
                var normalizedEntry = entry.TrimEnd('/');
                var entryWithSlash = normalizedEntry.StartsWith("/") ? normalizedEntry : "/" + normalizedEntry;

                // Exact match OR starts-with (sub-route)
                if (withSlash.Equals(entryWithSlash, StringComparison.OrdinalIgnoreCase) ||
                    withSlash.StartsWith(entryWithSlash + "/", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}