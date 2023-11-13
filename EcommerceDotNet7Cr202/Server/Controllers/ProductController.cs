using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDotNet7Cr202.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProductAsync();
            return Ok(result);
        }
        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {

            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }
        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductByCategory(string categoryUrl)
        {
            var result = await _productService.GetProductByCategory(categoryUrl);
            return Ok(result);
        }
        [HttpGet("search/{seachText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText)
        {
            var result = await _productService.SearchProduts(searchText);
            return Ok(result);
        }
        [HttpGet("searchsuggestions/{seachText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _productService.GetProductSearchSuggestions(searchText);
            return Ok(result);
        }
    }
}
