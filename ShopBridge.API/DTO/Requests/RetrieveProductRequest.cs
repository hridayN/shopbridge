using System;

namespace ShopBridge.API.DTO.Requests
{
    /// <summary>
    /// RetrieveProduct Request object
    /// </summary>
    public class RetrieveProductRequest
    {
        /// <summary>
        /// Product id
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
