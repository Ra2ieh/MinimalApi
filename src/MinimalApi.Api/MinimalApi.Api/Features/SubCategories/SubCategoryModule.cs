using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Contracts;
using MinimalApi.Api.Models;
using MinimalApi.Infrastructure;

namespace MinimalApi.Api.Features.SubCategories
{
    public class SubCategoryModule : IModule
    {
        public IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/v1/subCategories", async (MinimalApiDbContext ctx) =>
            {
                var subCategory = await ctx.SubCategory.ToListAsync();
                return subCategory;
            });
            endpoints.MapGet("/api/v2/subCategories", async (IMediator mediator) =>
            {
                var request = new GetSubCategoriesQuery();
                var subCategory = await mediator.Send(request);
                return subCategory;
            });
            endpoints.MapPost("/api/v1/subCategories", async (MinimalApiDbContext ctx, SubCategoryDto authorDto) =>
            {
                var subCategory = new Domain.Models.SubCategory();
                subCategory.Name = authorDto.Name;
                subCategory.CategoryId = authorDto.CategoryId;


                ctx.SubCategory.Add(subCategory);
                await ctx.SaveChangesAsync();

                return subCategory;
            });
            endpoints.MapPost("/api/v2/subCategories", async (IMediator mediator, SubCategoryDto SubcategoryDto) =>
            {
                var command = new CreateSubCategoryCommand { SubCategoryDto = SubcategoryDto };
                var subCategory = await mediator.Send(command);

                return subCategory;
            });
            return endpoints;
        }
    }
}
