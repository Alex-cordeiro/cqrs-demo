using CQRS.Demo.API;
using CQRS.Demo.API.CQRS;
using CQRS.Demo.API.Data;
using CQRS.Demo.API.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var configuration = (IConfiguration)builder.Configuration.AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true);

var connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(connectionString));


builder.Services.AddDataDependencies();
builder.Services.AddCQRSDependencies();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

VeiculoEndpoints.Map(app);

app.Run();
