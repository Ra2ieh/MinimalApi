using MediatR;
using MinimalApi.Api.Models;

namespace MinimalApi.Api.Features.SubCategories
{
    public class CreateSubCategoryCommand:IRequest
    {
        public SubCategoryDto SubCategoryDto { get; set; } = default!;
    }
}
