using ShopBridge.API.DTO.Requests;
using ShopBridge.API.DTO.Responses;
using System.Threading.Tasks;

namespace ShopBridge.API.Services.Contract
{
    public interface IProductService
    {
        /// <summary>
        /// SaveProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<SaveProductResponse> SaveProduct(SaveProductRequest request);
    }
}
