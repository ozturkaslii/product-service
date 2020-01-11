using AutoMapper;
using ProductCatalog.API.Entities;
using ProductCatalog.API.Models.Responses;

namespace ProductCatalog.API.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductGetResponseModel>();
            CreateMap<ProductGetResponseModel, Product>();
        }
    }
}