using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.DTO.Requests;
using ShopBridge.API.DTO.Responses;
using ShopBridge.API.Services.Contract;
using System.Threading.Tasks;

namespace ShopBridge.API.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
    [ApiController]
    public class ProductController : BaseController
    {
        /// <summary>
        /// ProductService interface object
        /// </summary>
        private readonly IProductService _productService;

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("saveProduct/product")]
        public async Task<IActionResult> SaveProduct(SaveProductRequest request)
        {
            SaveProductResponse response = await _productService.SaveProduct(request);
            return CreateResponse(response);
        }

        [HttpPost]
        [Route("retrieveProduct/product")]
        public async Task<IActionResult> RetrieveProduct(RetrieveProductRequest request)
        {
            RetrieveProductResponse response = await _productService.RetrieveProduct(request);
            return CreateResponse(response);
        }

        [HttpPost]
        [Route("deleteProduct/product")]
        public async Task<IActionResult> DeleteProduct(DeleteProductRequest request)
        {
            DeleteProductResponse response = await _productService.DeleteProduct(request);
            return CreateResponse(response);
        }
    }
}
