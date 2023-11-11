using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDotNet7Cr202.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly DataContext _context;
        private readonly IProductService _ProductService;

        public ProductController(IProductService productService)
        {
            //_context = context;
            _ProductService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            //var products = await _context.Products.ToListAsync();
            //var response = new ServiceResponse<List<Product>>()
            //{
            //    Data = products
            //};
            //return Ok(response);
            var result = await _ProductService.GetProductAsync();
            return Ok(result);
        }
        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {

            var result = await _ProductService.GetProductAsync(productId);
            return Ok(result);
        }
    }
}
