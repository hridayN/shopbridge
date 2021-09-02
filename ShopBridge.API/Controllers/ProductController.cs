using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.DTO.Requests;
using ShopBridge.API.DTO.Responses;
using ShopBridge.API.Services.Contract;
using System.Threading.Tasks;

namespace ShopBridge.API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("saveProduct/product")]
        public async Task<IActionResult> SaveProduct(SaveProductRequest request)
        {
            SaveProductResponse response = await _productService.SaveProduct(request);
            if (response.StatusCode == Enums.Enums.StatusCode.Ok)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
