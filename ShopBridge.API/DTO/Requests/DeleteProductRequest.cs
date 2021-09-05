using System;

namespace ShopBridge.API.DTO.Requests
{
    /// <summary>
    /// DeleteProduct Request object
    /// </summary>
    public class DeleteProductRequest
    {
        /// <summary>
        /// ProductId
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
