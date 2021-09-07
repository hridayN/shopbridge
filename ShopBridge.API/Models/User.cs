using System;

namespace ShopBridge.API.Models
{
    /// <summary>
    /// User model
    /// </summary>
    public class User
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User password
        /// </summary>
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
