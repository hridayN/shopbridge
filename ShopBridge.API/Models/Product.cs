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
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Product Offers
        /// </summary>
        public IEnumerable<Offer> Offers { get; set; }

        /// <summary>
        /// Available quantity of Product 
        /// </summary>
        public int AvailableQuantity { get; set; }

        /// <summary>
        /// Is Product a Gift
        /// </summary>
        public bool IsGift { get; set; }

        /// <summary>
        /// CreatedDate for Product
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Created By for Product
        /// </summary>
        public long CreatedBy { get; set; }

        /// <summary>
        /// ModifiedDate for Product
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Modified By for Product
        /// </summary>
        public long ModifiedBy { get; set; }
    }
}
