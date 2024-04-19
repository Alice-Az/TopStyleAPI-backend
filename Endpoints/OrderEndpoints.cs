using System.Security.Claims;
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
                OrderResponse? orderResponse = await orderService.CreateOrder(orderRequest);
                if (orderResponse != null) return Results.Ok(orderResponse);
                return Results.BadRequest();
            })
            .WithName("CreateOrder")
            .WithOpenApi();

            app.MapGet("/orders", async (ClaimsPrincipal user, IOrderService orderService) =>
            {
                var userId = user.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

                List<OrderResponse>? orderResponses = await orderService.GetMyOrders(int.Parse(userId));
                if (orderResponses != null) return Results.Ok(orderResponses);
                //if (orderResponses != null) return Results.StatusCode(StatusCodes.Status500InternalServerError);
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            })
            .RequireAuthorization()
            .WithName("GetMyOrders")
            .WithOpenApi();

            app.MapGet("/order/{orderID}", async (int orderID, IOrderService orderService) =>
            {
                OrderDetailedResponse? orderResponse = await orderService.GetOrderDetails(orderID);
                if (orderResponse != null) return Results.Ok(orderResponse);
                return Results.BadRequest();
            })
            .WithName("GetOrderDetails")
            .WithOpenApi();

        }
    }
}
