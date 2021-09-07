using ShopBridge.API.DTO.Requests;
using ShopBridge.API.DTO.Responses;
using System.Threading.Tasks;

namespace ShopBridge.API.Services.Contracts
{
    /// <summary>
    /// Interface for user action methods
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// SaveUser method to save/update user info
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<SaveUserResponse> SaveUser(SaveUserRequest request);

        /// <summary>
        /// Method to retrieve the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RetrieveUserResponse> RetrieveUser(RetrieveUserRequest request);

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginResponse> Login(LoginRequest request);
    }
}
