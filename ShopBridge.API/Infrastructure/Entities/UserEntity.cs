using ShopBridge.API.Constants;
using ShopBridge.API.Infrastructure.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.API.Infrastructure.Entities
{
    [Table("user", Schema = TableSchema.User)]
    public class UserEntity : Entity
    {
        /// <summary>
        /// User id
        /// </summary>
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// CreatedDate for Product
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// ModifiedDate for Product
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
