using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.Models.Order;

namespace TopStyleAPI.Endpoints
{
    public static class OrderEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapPost("/order", async (OrderRequest orderRequest, IOrderService orderService) =>
            {
                return await orderService.CreateOrder(orderRequest);
            })
            .WithName("CreateOrder")
            .WithOpenApi();

            app.MapGet("/orders/{userID}", async (int userID, IOrderService orderService) =>
            {
                return await orderService.GetMyOrders(userID);
            })
            .WithName("GetMyOrders")
            .WithOpenApi();

            app.MapGet("/order/{orderID}", async (int orderID, IOrderService orderService) =>
            {
                return await orderService.GetOrderDetails(orderID);
            })
            .WithName("GetOrderDetails")
            .WithOpenApi();

        }
    }
}
