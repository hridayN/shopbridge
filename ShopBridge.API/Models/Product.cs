using System;
using System.Collections.Generic;
using static ShopBridge.API.Enums.Enums;

namespace ShopBridge.API.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// GUID for Product
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Product Tax
        /// </summary>
        public double Tax { get; set; } = 18;

        /// <summary>
        /// Is Product refundable
        /// </summary>
        public bool IsRefundable { get; set; }

        /// <summary>
        /// Product Category
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// Flag to detect if product is available
        /// </summary>
        public string IsAvailable { get; set; }

        /// <summary>
        /// Product Offers
        /// </summary>
        public IEnumerable<Offer> Offers { get; set; }
    }
}
