using MediatR;
using MinimalApi.Api.Models;

namespace MinimalApi.Api.Features.Categories
{
    public class CreateCategoryCommand:IRequest
    {
        public CategoryDto CategoryDto { get; set; } = default!;
    }
}
