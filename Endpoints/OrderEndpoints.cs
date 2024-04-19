using System.Security.Claims;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.Models.Order;
using TopStyleAPI.Helpers;

namespace TopStyleAPI.Endpoints
{
    public static class OrderEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapPost("/order", async (OrderRequest orderRequest, ClaimsPrincipal user, IOrderService orderService) =>
            {
                OrderResponse? orderResponse = await orderService.CreateOrder(orderRequest, user.GetUserId());
                if (orderResponse != null) return Results.Ok(orderResponse);
                return Results.BadRequest();
            })
            .RequireAuthorization()
            .WithName("CreateOrder")
            .WithOpenApi();

            app.MapGet("/orders", async (ClaimsPrincipal user, IOrderService orderService) =>
            {
                List<OrderResponse>? orderResponses = await orderService.GetMyOrders(user.GetUserId());
                if (orderResponses != null) return Results.Ok(orderResponses);
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            })
            .RequireAuthorization()
            .WithName("GetMyOrders")
            .WithOpenApi();

            app.MapGet("/order/{orderID}", async (int orderID, ClaimsPrincipal user, IOrderService orderService) =>
            {
                OrderDetailedResponse? orderResponse = await orderService.GetOrderDetails(orderID);
                if (orderResponse != null && orderResponse.UserId == user.GetUserId()) return Results.Ok(orderResponse);
                return Results.BadRequest();
            })
            .RequireAuthorization()
            .WithName("GetOrderDetails")
            .WithOpenApi();

        }
    }
}
