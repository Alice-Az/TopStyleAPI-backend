using Microsoft.AspNetCore.Mvc;
using TopStyleAPI.Core.Interfaces;

namespace TopStyleAPI.Endpoints
{
    public static class ProductEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {

            app.MapGet("/product/{productID}", async (int productID, IProductService productService) =>
            {
                return await productService.GetProductyId(productID);
            })
            .WithName("GetProduct")
            .WithOpenApi();

            app.MapGet("/products", async ([FromQuery] string? search, IProductService productService) =>
            {
                return await productService.GetProducts(search ?? string.Empty);
            })
            .WithName("GetProducts")
            .WithOpenApi();
        }
    }
}
