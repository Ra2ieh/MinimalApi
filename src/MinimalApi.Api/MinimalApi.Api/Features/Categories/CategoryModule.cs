using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Contracts;
using MinimalApi.Api.Models;
using MinimalApi.Infrastructure;

namespace MinimalApi.Api.Features.Categories
{
    public class CategoryModule : IModule
    {
        public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/v2/categories", async (MinimalApiDbContext ctx) =>
            {
                var category = await ctx.Category.ToListAsync();
                return category;
            });
            endpoints.MapGet("/api/v3/categories", async (IMediator mediator) =>
            {
                var request = new GetCategoriesQuery();
                var authors = await mediator.Send(request);
                return authors;
            });
            endpoints.MapPost("/api/v2/categories", async (MinimalApiDbContext ctx, CategoryDto authorDto) =>
            {
                var category = new Domain.Models.Category();
                category.Name = authorDto.Name;


                ctx.Category.Add(category);
                await ctx.SaveChangesAsync();

                return category;
            });
            endpoints.MapPost("/api/v3/categories", async (IMediator mediator, CategoryDto categoryDto) =>
            {
                var command = new CreateCategoryCommand { CategoryDto = categoryDto };
                var category = await mediator.Send(command);

                return category;
            });
            return endpoints;
        }
    }
}
