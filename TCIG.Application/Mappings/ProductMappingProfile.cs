using AutoMapper;
using TCIG.Application.DTOs;
using TCIG.Domain.Entities;

namespace TCIG.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductModel, ProductDto>();
            CreateMap<CreateProductDto, ProductModel>();
            CreateMap<UpdateProductDto, ProductModel>();
        }
    }
}
