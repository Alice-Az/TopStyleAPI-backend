using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IOrderRepo
    {
        Order CreateOrder(Order order);
        Order? GetOrderDetails(int orderID);
        List<Order> GetMyOrders(int userID);
    }
}
