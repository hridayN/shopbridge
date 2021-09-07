namespace ShopBridge.API.DTO.Requests
{
    /// <summary>
    /// Login request model
    /// </summary>
    public class LoginRequest
    {
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
