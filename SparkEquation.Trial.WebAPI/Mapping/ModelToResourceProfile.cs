using AutoMapper;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Resources;

namespace SparkEquation.Trial.WebAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<CategoryProduct, CategoryProductResource>();
            CreateMap<Brand, BrandResource>();
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
        }
    }
}
