using AutoMapper;
using System;

namespace ShopBridge.API.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ShopBridgeProductDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper => Lazy.Value;
    }
}
