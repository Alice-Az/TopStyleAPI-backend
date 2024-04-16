using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.Product;

namespace TopStyleAPI.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly TopStyleContext _context;

        public ProductService(TopStyleContext context)
        {
            _context = context;
        }

        public ProductResponse GetProduct(int productID)
        {

            //using TopStyleContext db = new();

            //Product? product = db.Products.SingleOrDefault(p => p.Id == productID);

            Product? product = _context.Products.SingleOrDefault(p => p.Id == productID);

            ProductResponse response = new()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductImage = product.ProductImage
            };

            return response;
        }

        public List<ProductResponse> GetProducts(string input)
        {
            //using TopStyleContext db = new();

            //List<Product> products = db.Products.Where(p => p.ProductName.Contains(input)).ToList();

            List<Product> products = _context.Products.Where(p => p.ProductName.Contains(input)).ToList();

            List<ProductResponse> responses = new();

            foreach (Product product in products)
            {
                ProductResponse response = new()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductImage = product.ProductImage
                };
                responses.Add(response);
            };

            return responses;
        }

    }
}
