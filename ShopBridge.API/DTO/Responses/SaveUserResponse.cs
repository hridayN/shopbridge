using System;

namespace ShopBridge.API.DTO.Responses
{
    /// <summary>
    /// Save user response model
    /// </summary>
    public class SaveUserResponse : BaseResponse
    {
        /// <summary>
        /// UserId
        /// </summary>
        public Guid UserId { get; set; }
    }
}
