using ShopBridge.API.Models;

namespace ShopBridge.API.DTO.Responses
{
    /// <summary>
    /// RetrieveUser response model
    /// </summary>
    public class RetrieveUserResponse : BaseResponse
    {
        /// <summary>
        /// User object
        /// </summary>
        public User User { get; set; }
    }
}
