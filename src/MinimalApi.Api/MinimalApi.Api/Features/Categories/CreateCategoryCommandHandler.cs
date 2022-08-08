using MediatR;
using MinimalApi.Domain.Models;
using MinimalApi.Infrastructure;

namespace MinimalApi.Api.Features.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly MinimalApiDbContext _context;
        public CreateCategoryCommandHandler(MinimalApiDbContext context)
        {
            _context = context;
        }

         async Task<Unit> IRequestHandler<CreateCategoryCommand, Unit>.Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var toAdd = new Category
            {
                Name = request.CategoryDto.Name,
            };
            _context.Category.Add(toAdd);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
