using ShopBridge.API.Models;

namespace ShopBridge.API.DTO.Requests
{
    /// <summary>
    /// Save user request model
    /// </summary>
    public class SaveUserRequest
    {
        /// <summary>
        /// User model
        /// </summary>
        public User User { get; set; }
    }
}
