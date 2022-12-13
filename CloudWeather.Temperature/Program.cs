using CloudWeather.Temperature.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TemperatureDbContext>(
    opts =>
    {
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
    }, ServiceLifetime.Transient
);

var app = builder.Build();

app.MapGet("/observation/{zip}", async (string zip, [FromQuery] int? days, TemperatureDbContext db) => {
    if (days == null || days < 0 || days > 30)
        return Results.BadRequest("Please provide a 'days' query parameter between 1 and 30");

    var startDate = DateTime.UtcNow - TimeSpan.FromDays(days.Value);
    var results = await db.Temperatures
        .Where(temp => temp.ZipCode == zip && temp.CreatedOn > startDate)
        .ToListAsync();

    return Results.Ok(results);
});

app.MapPost("/observation", async (Temperature temperature, TemperatureDbContext context) =>
{
    temperature.CreatedOn = temperature.CreatedOn.ToUniversalTime();
    await context.AddAsync(temperature);
    await context.SaveChangesAsync();
});

app.Run();