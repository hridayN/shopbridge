using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.DTO.Requests;
using ShopBridge.API.DTO.Responses;
using ShopBridge.API.Services.Contracts;
using System.Threading.Tasks;

namespace ShopBridge.API.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [ApiController]
    public class UserController : BaseController
    {
        /// <summary>
        /// IUserService variable
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login/user")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginResponse response = await _userService.Login(request);
            return (response.StatusCode == Enums.Enums.StatusCode.Ok) ? Ok(new { Token = response.Token }) : CreateResponse(response);
        }


        /// <summary>
        /// SaveUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("saveUser/user")]
        public async Task<IActionResult> SaveUser(SaveUserRequest request)
        {
            SaveUserResponse response = await _userService.SaveUser(request);
            return CreateResponse(response);
        }

        /// <summary>
        /// RetrieveUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, Authorize]
        [Route("retrieveUser/user")]
        public async Task<IActionResult> RetrieveUser(RetrieveUserRequest request)
        {
            RetrieveUserResponse response = await _userService.RetrieveUser(request);
            return CreateResponse(response);
        }
    }
}
