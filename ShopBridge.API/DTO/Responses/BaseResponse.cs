using static ShopBridge.API.Enums.Enums;

namespace ShopBridge.API.DTO.Responses
{
    /// <summary>
    /// Base response object
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        public StatusCode StatusCode { get; set; }
    }
}
