namespace EcommerceDotNet7Cr202.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _Context;

        public ProductService(DataContext context)
        {
            _Context = context;
        }
        public async Task<ServiceResponse<List<Product>>> GetProductAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _Context.Products.ToListAsync()
            };

            return response;
        }
    }
}
