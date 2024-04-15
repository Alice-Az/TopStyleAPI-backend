using TopStyleAPI.Domain.Models.Product;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IProductService
    {
        ProductResponse GetProduct(int productID);
        List<ProductResponse> GetProducts(string input);

    }
}
