using ShopBridge.API.Models;

namespace ShopBridge.API.DTO.Responses
{
    /// <summary>
    /// Save product response object
    /// </summary>
    public class SaveProductResponse : BaseResponse
    {
        /// <summary>
        /// Product object
        /// </summary>
        public Product Product { get; set; }
    }
}
