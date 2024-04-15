using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.Order;

namespace TopStyleAPI.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IProductRepo _productRepo;

        public OrderService(IOrderRepo orderRepo, IProductRepo productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        public OrderResponse CreateOrder(OrderRequest orderRequest)
        {
            List<Product> products = _productRepo.GetOrderProducts(orderRequest.ProductIDs);

            decimal totalPrice = 0;

            List<OrderProduct> orderProducts = new();

            foreach (Product product in products)
            {
                orderProducts.Add(new OrderProduct() { ProductId = product.Id});
                totalPrice += product.ProductPrice;
            }

            Order order = new()
            {
                UserId = orderRequest.UserID,
                OrderPrice = totalPrice,
                OrderProducts = orderProducts,
                FullName = orderRequest.FullName,
                Address = orderRequest.Address,
                ZipCode = orderRequest.ZipCode,
                City = orderRequest.City,
            };

            Order createdOrder = _orderRepo.CreateOrder(order);

            OrderResponse orderResponse = new()
            {
                OrderID = createdOrder.Id,
                UserID = createdOrder.UserId,
                Price = createdOrder.OrderPrice
            };
            return orderResponse;

        }

        //public OrderDetailedResponse GetOrderDetails(int orderID)
        //{
        //    using TopStyleContext db = new();

        //    List<OrderProductResponse> orderProductResponseList = new();

        //    Order? order = db.Orders.SingleOrDefault(o => o.OrderId == orderID);

        //    List<OrderProduct>? orderProductList = db.OrderProducts.Where(op => op.OrderId == order.OrderId).ToList();

        //    foreach (OrderProduct orderProduct in orderProductList)
        //    {
        //        List<Product>? products = db.Products.Where(p => p.ProductId == orderProduct.ProductId).ToList();

        //        foreach (Product product in products)
        //        {
        //            OrderProductResponse productResponse = new()
        //            {
        //                ProductID = product.ProductId,
        //                Name = product.ProductName,
        //                Image = product.ProductImage
        //            };
        //            orderProductResponseList.Add(productResponse);
        //        };
        //    };

        //    OrderDetailedResponse orderDetailedResponse = new()
        //    {
        //        OrderID = order.OrderId,
        //        UserID = order.UserId,
        //        Price = order.OrderPrice,
        //        Products = orderProductResponseList
        //    };

        //    return orderDetailedResponse;
        //}

        public List<OrderResponse> GetMyOrders(int userID)
        {
            using TopStyleContext db = new();

            List<Order>? orders = db.Orders.Where(o => o.UserId == userID).ToList();

            List<OrderResponse> orderResponses = new();

            foreach (Order order in orders)
            {
                OrderResponse orderResponse = new()
                {
                    OrderID = order.Id,
                    UserID = order.UserId,
                    Price = order.OrderPrice,
                    FullName = order.FullName,
                    Address = order.Address,
                    ZipCode = order.ZipCode,
                    City = order.City,
                };
                orderResponses.Add(orderResponse);
            };
            return orderResponses;
        }

        public OrderDetailedResponse GetOrderDetails(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}
