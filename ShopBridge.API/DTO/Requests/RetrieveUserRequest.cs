using System;

namespace ShopBridge.API.DTO.Requests
{
    /// <summary>
    /// RetrieveUser request model
    /// </summary>
    public class RetrieveUserRequest
    {
        /// <summary>
        /// UserId
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
    }
}
