using ShopBridge.API.Models;
using System.Collections.Generic;

namespace ShopBridge.API.DTO.Responses
{
    /// <summary>
    /// SearchProduct Response object
    /// </summary>
    public class SearchProductResponse : BaseResponse
    {
        /// <summary>
        /// Products
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
