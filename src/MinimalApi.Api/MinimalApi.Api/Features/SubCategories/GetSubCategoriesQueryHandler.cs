using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Api.Models;
using MinimalApi.Domain.Models;
using MinimalApi.Infrastructure;

namespace MinimalApi.Api.Features.SubCategories
{
    public class GetSubCategoriesQueryHandler : IRequestHandler<GetSubCategoriesQuery, List<SubCategoryDto>>
    {
        private readonly MinimalApiDbContext _context;
        private readonly IMapper _mapper;
        public GetSubCategoriesQueryHandler(MinimalApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
            
        public async Task<List<SubCategoryDto>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
        {
             var result=await _context.SubCategory.ToListAsync(cancellationToken);
            var response =new List<SubCategoryDto>();
            foreach (var subCategory in result)
            {
                response.Add(_mapper.Map<SubCategoryDto>(subCategory));
            }
            return response ;
        }
    }
}
