using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.Product;

namespace TopStyleAPI.Core.Services
{
    public class ProductService : IProductService
    {
        public ProductResponse GetProduct(int productID)
        {

            using TopStyleContext db = new();

            Product? product = db.Products.SingleOrDefault(p => p.Id == productID);

            ProductResponse response = new()
            {
                ProductID = product.Id,
                Name = product.ProductName,
                Description = product.ProductDescription,
                Price = product.ProductPrice,
                Image = product.ProductImage
            };

            return response;
        }

        public List<ProductResponse> GetProducts(string input)
        {
            using TopStyleContext db = new();

            List<Product> products = db.Products.Where(p => p.ProductName.Contains(input)).ToList();

            List<ProductResponse> responses = new();

            foreach (Product product in products)
            {
                ProductResponse response = new()
                {
                    ProductID = product.Id,
                    Name = product.ProductName,
                    Description = product.ProductDescription,
                    Price = product.ProductPrice,
                    Image = product.ProductImage
                };
                responses.Add(response);
            };

            return responses;
        }

    }
}
