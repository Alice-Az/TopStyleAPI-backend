using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Core.Services;
using TopStyleAPI.Domain.Models.Order;

namespace TopStyleAPI.Endpoints
{
    public static class OrderEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapPost("/order", (OrderRequest orderRequest, IOrderService orderService) =>
            {
                return orderService.CreateOrder(orderRequest);
            })
            .WithName("CreateOrder")
            .WithOpenApi();

            app.MapGet("/orders/{userID}", (int userID, IOrderService orderService) =>
            {
                return orderService.GetMyOrders(userID);
            })
            .WithName("GetMyOrders")
            .WithOpenApi();

            app.MapGet("/order/{orderID}", (int orderID, IOrderService orderService) =>
            {
                return orderService.GetOrderDetails(orderID);
            })
            .WithName("GetOrderDetails")
            .WithOpenApi();

        }
    }
}
