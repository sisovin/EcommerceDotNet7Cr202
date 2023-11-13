namespace EcommerceDotNet7Cr202.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl);
        Task<ServiceResponse<List<Product>>> SearchProduts(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
    }
}
