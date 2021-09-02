using ShopBridge.API.Models;

namespace ShopBridge.API.DTO.Requests
{
    /// <summary>
    /// Save product request object
    /// </summary>
    public class SaveProductRequest
    {
        /// <summary>
        /// Product object
        /// </summary>
        public Product Product { get; set; }
    }
}
