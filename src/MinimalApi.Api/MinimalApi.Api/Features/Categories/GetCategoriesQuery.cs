using MediatR;
using MinimalApi.Domain.Models;

namespace MinimalApi.Api.Features.Categories
{
    public class GetCategoriesQuery:IRequest<List<Category>>
    {

    }
}
