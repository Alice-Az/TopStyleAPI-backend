using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IProductRepo
    {
        List<Product> GetOrderProducts(List<int> productsIds);

    }
}
