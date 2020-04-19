using AutoMapper;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Resources;

namespace SparkEquation.Trial.WebAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CategoryProductResource, CategoryProduct>();
            CreateMap<BrandResource, Brand>();
            CreateMap<CategoryResource, Category>();
            CreateMap<ProductResource, Product>();
            CreateMap<SaveProductResource, Product>();
        }
    }
}
