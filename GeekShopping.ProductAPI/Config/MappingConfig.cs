using AutoMapper;
using GeekShopping.ProductAPI.Model.Product;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>{
                config.CreateMap<ProductRequest, Product>();
                config.CreateMap<ProductResponse, Product>();
                config.CreateMap<Product, ProductRequest>();
                config.CreateMap<Product, ProductResponse>();
            });
            return mappingConfig;

        }
    }
}
