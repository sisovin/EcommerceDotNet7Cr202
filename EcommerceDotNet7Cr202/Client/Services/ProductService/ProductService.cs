namespace EcommerceDotNet7Cr202.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _Http;

        public ProductService(HttpClient http)
        {
            _Http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result =
                await _Http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts()
        {
            var result = 
                await _Http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            if (result != null && result.Data != null)
                Products = result.Data;
        }
    }
}
