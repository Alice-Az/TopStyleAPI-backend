using Microsoft.AspNetCore.Mvc;
using TopStyleAPI.Core.Interfaces;

namespace TopStyleAPI.Endpoints
{
    public static class ProductEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {

            app.MapGet("/product/{productID}", (int productID, IProductService productService) =>
            {
                return productService.GetProduct(productID);
            })
            .WithName("GetProduct")
            .WithOpenApi();

            app.MapGet("/products", ([FromQuery] string? search, IProductService productService) =>
            {
                return productService.GetProducts(search ?? string.Empty);
            })
            .WithName("GetProducts")
            .WithOpenApi();
        }
    }
}
