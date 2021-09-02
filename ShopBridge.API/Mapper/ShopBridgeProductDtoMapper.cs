using AutoMapper;
using ShopBridge.API.Infrastructure.Entities;
using ShopBridge.API.Models;

namespace ShopBridge.API.Mapper
{
    public class ShopBridgeProductDtoMapper : Profile
    {
        public ShopBridgeProductDtoMapper()
        {
            CreateMap<Product, ProductEntity>();
            CreateMap<ProductEntity, Product>();
        }
    }
}
