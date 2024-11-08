﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDotNet7Cr202.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";

        public event Action ProductsChanged;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            if (result != null && result.Data != null)
                Products = result.Data;

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http
              .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}?searchText={searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}?searchText={searchText}");
            if (result != null && result.Data != null)
                Products = result.Data;
            if (Products.Count == 0) Message = "No products ware found.";
            ProductsChanged?.Invoke();
        }
    }
}
