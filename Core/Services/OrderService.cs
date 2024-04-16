using AutoMapper;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.Order;

namespace TopStyleAPI.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepo orderRepo, IProductRepo productRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public OrderResponse CreateOrder(OrderRequest orderRequest)
        {
            List<Product> products = _productRepo.GetOrderProducts(orderRequest.ProductIDs);

            decimal totalPrice = 0;

            List<OrderProduct> orderProducts = products.Select(p => new OrderProduct() { ProductId = p.Id }).ToList();
            totalPrice = products.Sum(p => p.ProductPrice);

            Order order = _mapper.Map<Order>(orderRequest);
            order.OrderPrice = totalPrice;
            order.OrderProducts = orderProducts;            

            Order createdOrder = _orderRepo.CreateOrder(order);

            OrderResponse response = _mapper.Map<OrderResponse>(createdOrder);
            return response;

        }

        public OrderDetailedResponse GetOrderDetails(int orderID)
        {
            Order? order = _orderRepo.GetOrderDetails(orderID);

            List<OrderProductResponse> orderProductResponseList = order.OrderProducts.Select(op => _mapper.Map<OrderProductResponse>(op.Product)).ToList();

            OrderDetailedResponse orderResponse = _mapper.Map<OrderDetailedResponse>(order);
            orderResponse.Products = orderProductResponseList;

            return orderResponse;
        }

        public List<OrderResponse> GetMyOrders(int userID)
        {
            List<Order>? orders = _orderRepo.GetMyOrders(userID);
            return _mapper.Map<List<OrderResponse>>(orders);
        }

    }
}
