using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IOrderRepo
    {
        Task<Order?> CreateOrder(Order order);
        Task<Order?> GetOrderDetails(int orderID);
        Task<List<Order>?> GetMyOrders(int userID);
    }
}
