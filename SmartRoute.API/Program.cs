using SmartRoute.Application.Interfaces;
using SmartRoute.Application.Services;
using Microsoft.EntityFrameworkCore;
using SmartRoute.Infrastructure.Persistence;
using SmartRoute.Infrastructure.DependencyInjection;
using SmartRoute.API.Middlewares;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);

// Sets Serilog: Console logs only in dev, SQL only for errors
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // útil em dev
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "Logs",
            AutoCreateSqlTable = true
        },
        restrictedToMinimumLevel: LogEventLevel.Error
    )
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddMediatRServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();

builder.Services.AddDbContext<SmartRouteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHealthChecks();



var app = builder.Build();

app.MapHealthChecks("/health"); // endpoint: https://localhost:5001/health

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware for controller exceptions
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
