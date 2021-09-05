using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.DTO.Responses;

namespace ShopBridge.API.Controllers
{
    /// <summary>
    /// Base contoller for common functionality
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        ///  Method to return response object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        protected IActionResult CreateResponse<T>(T response) where T : BaseResponse
        {
            return response.StatusCode switch
            {
                Enums.Enums.StatusCode.Conflict => Conflict(response),
                Enums.Enums.StatusCode.BadRequest => BadRequest(response),
                Enums.Enums.StatusCode.NotFound => NotFound(response),
                _ => Ok(response)
            };
        }
    }
}
