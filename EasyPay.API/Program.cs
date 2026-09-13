
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

//using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.EntityFrameworkCore;
using NibbssNPSPaymentStack.API.Middleware;
using NibbssNPSPaymentStack.Business.Contract;
using NibbssNPSPaymentStack.Business.Models;
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

Log.Information("NPS API Programram engine starting");



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





builder.Services.AddHttpClient();

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
options.UseSqlServer(builder.Configuration.GetConnectionString("NPSDBConnection")));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();
app.Run();
