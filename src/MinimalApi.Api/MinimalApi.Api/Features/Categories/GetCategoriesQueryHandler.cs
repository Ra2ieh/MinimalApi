using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Models;
using MinimalApi.Infrastructure;

namespace MinimalApi.Api.Features.Categories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly MinimalApiDbContext _context;
        public GetCategoriesQueryHandler(MinimalApiDbContext context)
        {
            _context = context;
        }
            
        public Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _context.Category.ToListAsync(cancellationToken);
        }
    }
}
