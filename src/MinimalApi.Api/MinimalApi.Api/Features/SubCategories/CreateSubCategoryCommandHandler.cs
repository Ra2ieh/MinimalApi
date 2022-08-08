using MediatR;
using MinimalApi.Domain.Models;
using MinimalApi.Infrastructure;

namespace MinimalApi.Api.Features.SubCategories
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand>
    {
        private readonly MinimalApiDbContext _context;
        public CreateSubCategoryCommandHandler(MinimalApiDbContext context)
        {
            _context = context;
        }

         async Task<Unit> IRequestHandler<CreateSubCategoryCommand, Unit>.Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var toAdd = new SubCategory
            {
                Name = request.SubCategoryDto.Name,
                CategoryId = request.SubCategoryDto.CategoryId,
            };
            _context.SubCategory.Add(toAdd);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
