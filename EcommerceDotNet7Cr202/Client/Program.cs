global using EcommerceDotNet7Cr202.Shared;
global using EcommerceDotNet7Cr202.Client.Pages;
global using EcommerceDotNet7Cr202.Client.Services.ProductService;
global using EcommerceDotNet7Cr202.Client.Services.CategoryService;
global using System.Net.Http.Json;
using EcommerceDotNet7Cr202.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

await builder.Build().RunAsync();
