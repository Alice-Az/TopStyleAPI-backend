using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly TopStyleContext _context;

        public ProductRepo(TopStyleContext context)
        {
            _context = context;
        }

        public async Task<List<Product?>> GetOrderProducts(List<int> productsIds)
        {
            List<Product?> products = [];
            foreach(int productId in productsIds)
            {
                Product? product = await _context.Products.SingleOrDefaultAsync(p => p.Id == productId);
                if (product != null) products.Add(product);
            }

            return products;
        }

        public async Task<Product?> GetProductById(int productId)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<Product>?> GetProducts(string input)
        {
            return await _context.Products.Where(p => p.ProductName.Contains(input)).ToListAsync();
        }
    }
}
