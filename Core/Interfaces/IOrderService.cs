using TopStyleAPI.Domain.Models.Order;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse?> CreateOrder(OrderRequest orderRequest, int userId);
        Task<OrderDetailedResponse?> GetOrderDetails(int orderID);
        Task<List<OrderResponse>?> GetMyOrders(int userID);

    }
}
