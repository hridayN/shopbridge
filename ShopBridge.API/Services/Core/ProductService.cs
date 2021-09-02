using ShopBridge.API.DTO.Requests;
using ShopBridge.API.DTO.Responses;
using ShopBridge.API.Infrastructure.Contracts.Base;
using ShopBridge.API.Infrastructure.Entities;
using ShopBridge.API.Mapper;
using ShopBridge.API.Models;
using ShopBridge.API.Services.Contract;
using System;
using System.Threading.Tasks;
using static ShopBridge.API.Enums.Enums;

namespace ShopBridge.API.Services.Core
{
    public class ProductService : IProductService
    {
        private readonly IRepository<ProductEntity> _productRepository;

        public ProductService(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }
        /// <summary>
        /// SaveProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<SaveProductResponse> SaveProduct(SaveProductRequest request)
        {
            SaveProductResponse response = new SaveProductResponse();
            ProductEntity productEntity;

            if (request.Product.Id != null)
            {
                var savedProductResponse = await _productRepository.GetByIdAsync(request.Product.Id.ToString());
                if (savedProductResponse != null)
                {
                    savedProductResponse.ModifiedBy = 1;
                    savedProductResponse.ModifiedDate = DateTime.Now;
                    ObjectMapper.Mapper.Map(request.Product, savedProductResponse);
                    await _productRepository.UpdateAsync(savedProductResponse);
                    response.Product = ObjectMapper.Mapper.Map<Product>(savedProductResponse);
                    response.Message = "Product updated successfully";
                }
                else
                {
                    response.StatusCode = StatusCode.BadRequest;
                    response.Message = "No product found with given Id";
                    return response;
                }
            } else
            {
                request.Product.CreatedBy = 1;
                request.Product.CreatedDate = DateTime.Now;
                request.Product.ModifiedBy = 1;
                request.Product.ModifiedDate = DateTime.Now;
                productEntity = ObjectMapper.Mapper.Map<ProductEntity>(request.Product);
                var savedProduct = await _productRepository.AddAsync(productEntity);
                response.Product = ObjectMapper.Mapper.Map<Product>(savedProduct);
                response.Message = "Product saved successfully";
            }
            response.StatusCode = StatusCode.Ok;
            return response;
        }
    }
}
