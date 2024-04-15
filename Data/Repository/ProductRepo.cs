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

        public List<Product> GetOrderProducts(List<int> productsIds)
        {
            List<Product> products = new();

            foreach(int productId in productsIds)
            {
                Product? product = _context.Products.SingleOrDefault(p => p.Id == productId);
                if (product != null) products.Add(product);
            }
            return products;
        }
    }
}
