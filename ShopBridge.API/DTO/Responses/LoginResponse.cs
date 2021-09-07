namespace ShopBridge.API.DTO.Responses
{
    /// <summary>
    /// Login response model
    /// </summary>
    public class LoginResponse : BaseResponse
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }
}
