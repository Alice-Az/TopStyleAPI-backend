using TopStyleAPI.Domain.Models.Product;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse?> GetProductyId(int productID);
        Task<List<ProductResponse>?> GetProducts(string input);

    }
}
