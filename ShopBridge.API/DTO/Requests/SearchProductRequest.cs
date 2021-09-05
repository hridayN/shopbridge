using System.Collections.Generic;

namespace ShopBridge.API.DTO.Requests
{
    /// <summary>
    /// SearchProduct Request model
    /// </summary>
    public class SearchProductRequest
    {
        /// <summary>
        /// ProductIds
        /// </summary>
        public List<int> ProductIds { get; set; }
    }
}
