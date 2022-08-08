using AutoMapper;
using MinimalApi.Domain.Models;

namespace MinimalApi.Api.Models
{
    public class ModelMappes:Profile
    {
        public ModelMappes()
        {
            CreateMap<SubCategory, SubCategoryDto>();
            
        }
    }
}
