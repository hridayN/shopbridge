using ShopBridge.API.DTO.Requests;
using ShopBridge.API.DTO.Responses;
using System.Threading.Tasks;

namespace ShopBridge.API.Services.Contract
{
    /// <summary>
    /// Product Interface
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// SaveProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<SaveProductResponse> SaveProduct(SaveProductRequest request);

        /// <summary>
        /// RetrieveProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<RetrieveProductResponse> RetrieveProduct(RetrieveProductRequest request);

        /// <summary>
        /// SearchProducts
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<SearchProductResponse> SearchProducts(SearchProductRequest request);

        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request);
    }
}
