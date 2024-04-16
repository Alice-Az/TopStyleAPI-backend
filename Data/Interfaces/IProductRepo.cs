using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IProductRepo
    {
        Task<List<Product?>> GetOrderProducts(List<int> productsIds);
        Task<Product?> GetProductById(int productId);
        Task<List<Product>?> GetProducts(string input);

    }
}
