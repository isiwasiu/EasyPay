
//using Microsoft.AspNetCore.Identity.UI.Services;

//using Microsoft.AspNetCore.Authentication.BearerToken;
using EasyPay.API.Middleware;
using EasyPay.API.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NibbssNPSPaymentStack.API.Middleware;
using NibbssNPSPaymentStack.Business.Contract;
using NibbssNPSPaymentStack.Business.Models;
using Microsoft.OpenApi.Models;
using NibbssNPSPaymentStack.Business.Models.Camt053;
using NibbssNPSPaymentStack.Business.Services;
using NibssNPSPaymentStack.Data;
using NibssNPSPaymentStack.Data.Repositories;
using Serilog;
using System.Configuration;
using static NibbssNPSPaymentStack.Business.Services.NibssNPSPayments;

var builder = WebApplication.CreateBuilder(args);

// configure the serilog
Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .Enrich.FromLogContext()
                        .ReadFrom.Configuration(builder.Configuration)
                        .CreateLogger();

Log.Information("EasyPay API Programram engine starting");


builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddScoped<IDappeer, Dappeer>();
builder.Services.AddScoped<INpsRepositories, NpsRepositories>();
builder.Services.AddScoped<INibssNPSPayments, NibssNPSPayments>();
builder.Services.AddScoped<NibbssNPSPaymentStack.Business.Utility.NpsSecurity>();
builder.Services.Configure<GeolocationApi>(builder.Configuration.GetSection("GeolocationApi"));
builder.Services.Configure<NpsSettings>(builder.Configuration.GetSection("NpsSettings"));
//builder.Services.AddTransient<IEmailSender, EmailSender>(); 
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, new PlainTextInputFormatter());
});





builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyPay API", Version = "v1" });

    // --- DEFINITION 1: Bearer Token (JWT) ---
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by your JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    // --- DEFINITION 2: API Key (Custom Header) ---
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter your API Key here",
        Name = "API-Key",                 // <--- CHANGE THIS to exactly match your middleware
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });

    // Apply BOTH requirements globally
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        },
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            Array.Empty<string>()
        }
    });
});



builder.Services.AddHttpClient();
//builder.Services.AddControllers().AddXmlSerializerFormatters();
builder.Services.AddControllers();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Host.UseSerilog();
//builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<IdentityUser>();
builder.Services.AddAuthorization();



//builder.Services.AddAuthentication(
//    option =>
//    {
//        option.DefaultAuthenticateScheme.= JwtBearerDefaults.AuthenticateScheme;
//        option.DefaultChallengeScheme.= JwtBearerDefaults.AuthenticateScheme;
//        option.DefaultScheme.= JwtBearerDefaults.AuthenticateScheme;

//    });


//// 1. Add Identity services (required for IdentityDbContext)
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(
//    option =>
//    {
//        option.Password.RequireDigit = true;
//        option.Password.RequireLowercase = true;
//        option.Password.RequireUppercase = true;
//        option.Password.RequireNonAlphanumeric = false;
//        option.Password.RequiredLength = 8;
//        option.Password.RequiredUniqueChars = 4;

//    });


builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<NPSDBContext>()
                .AddDefaultTokenProviders();


builder.Services.AddDbContext<NPSDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EPayDatabase")));

builder.Services.AddScoped< IDappeer, Dappeer > ();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    // Tells ASP.NET to trust the X-Forwarded-For and X-Forwarded-Proto headers
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
    // Optional: Restrict to known proxies for security (recommended for production)
    // KnownProxies = { IPAddress.Parse("your-proxy-ip-here") }
});

app.UseHttpsRedirection();

//app.UseAuthorization();
// Outer → handles the final response body
app.UseMiddleware<ErrorResponseMiddleware>();

// Inner → sets status & context, then short‑circuits on failure
app.UseMiddleware<EasyPay.API.Middleware.UserRegistrationService>();


app.MapControllers();
app.MapIdentityApi<IdentityUser>();
app.Run();
