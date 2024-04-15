using TopStyleAPI.Domain.Models.Order;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IOrderService
    {
        OrderResponse CreateOrder(OrderRequest orderRequest);
        OrderDetailedResponse GetOrderDetails(int orderID);
        List<OrderResponse> GetMyOrders(int userID);

    }
}
