using MediatR;
using MinimalApi.Api.Models;
using MinimalApi.Domain.Models;

namespace MinimalApi.Api.Features.SubCategories
{
    public class GetSubCategoriesQuery : IRequest<List<SubCategoryDto>>
    {

    }
}
