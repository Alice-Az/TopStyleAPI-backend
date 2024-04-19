using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.Models.Product;

namespace TopStyleAPI.Endpoints
{
    public static class ProductEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {

            app.MapGet("/product/{productID}", async (int productID, IProductService productService) =>
            {
                ProductResponse? product = await productService.GetProductyId(productID);
                if (product != null) return Results.Ok(product);
                return Results.BadRequest();
            })
            .WithName("GetProduct")
            .WithOpenApi();

            app.MapGet("/products", async ([FromQuery] string? search, IProductService productService) =>
            {
                List<ProductResponse>? products = await productService.GetProducts(search ?? string.Empty);
                if (products != null) return Results.Ok(products);
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            })
            .WithName("GetProducts")
            .WithOpenApi();
        }
    }
}
