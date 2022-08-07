using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Models;
using MinimalApi.Domain.Models;
using MinimalApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MinimalApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MinimalApiConnectionString"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/api/categories", async (MinimalApiDbContext ctx) =>
{
    var category = await ctx.Category.ToListAsync();
    return category;
});
app.MapPost("/api/categories", async (MinimalApiDbContext ctx, CategoryDto authorDto) =>
{
    var category = new Category();
    category.Name = authorDto.Name;


    ctx.Category.Add(category);
    await ctx.SaveChangesAsync();

    return category;
});
app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}