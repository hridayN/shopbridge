using ShopBridge.API.Constants;
using ShopBridge.API.Infrastructure.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShopBridge.API.Enums.Enums;

namespace ShopBridge.API.Infrastructure.Entities
{
    [Table("product", Schema = TableSchema.Product)]
    public class ProductEntity : Entity
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [Column("price")]
        public double Price { get; set; }

        /// <summary>
        /// Product Tax
        /// </summary>
        [Column("tax")]
        public double Tax { get; set; } = 18;

        /// <summary>
        /// Is Product refundable
        /// </summary>
        [Column("is_refundable")]
        public bool IsRefundable { get; set; }

        /// <summary>
        /// Product Category
        /// </summary>
        [Column("category")]
        public string Category { get; set; }

        /// <summary>
        /// Flag to detect if product is available
        /// </summary>
        [Column("is_available")]
        public string IsAvailable { get; set; }

        /// <summary>
        /// Available quantity of Product 
        /// </summary>
        [Column("available_quantity")]
        public int AvailableQuantity { get; set; }

        /// <summary>
        /// Is Product a Gift
        /// </summary>
        [Column("is_gift")]
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
