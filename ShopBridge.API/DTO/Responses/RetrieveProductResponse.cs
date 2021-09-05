using ShopBridge.API.Models;

namespace ShopBridge.API.DTO.Responses
{
    /// <summary>
    /// RetrieveProduct Response object
    /// </summary>
    public class RetrieveProductResponse : BaseResponse
    {
        /// <summary>
        /// Product model
        /// </summary>
        public Product Product { get; set; }
    }
}
