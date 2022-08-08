using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Extensions;
using MinimalApi.Api.Models;
using MinimalApi.Domain.Models;
using MinimalApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices(builder);
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


app.MapGet("/api/v1/categories", async (MinimalApiDbContext ctx) =>
{
    var category = await ctx.Category.ToListAsync();
    return category;
});
app.MapPost("/api/v1/categories", async (MinimalApiDbContext ctx, CategoryDto authorDto) =>
{
    var category = new Category();
    category.Name = authorDto.Name;


    ctx.Category.Add(category);
    await ctx.SaveChangesAsync();

    return category;
});
app.RegisterEndpoints();
app.Run();
