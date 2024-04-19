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

        public async Task<OrderResponse?> CreateOrder(OrderRequest orderRequest, int userId)
        {
            List<Product>? products = await _productRepo.GetOrderProducts(orderRequest.ProductIDs);

            decimal totalPrice = 0;

            if (products == null) return null;

            List<OrderProduct> orderProducts = products.Select(p => new OrderProduct() { ProductId = p.Id }).ToList();
            totalPrice = products.Sum(p => p.ProductPrice);

            Order order = _mapper.Map<Order>(orderRequest);
            order.UserId = userId;
            order.OrderPrice = totalPrice;
            order.OrderProducts = orderProducts;            

            Order? createdOrder = await _orderRepo.CreateOrder(order);

            OrderResponse? response = _mapper.Map<OrderResponse?>(createdOrder);
            return response;

        }

        public async Task<OrderDetailedResponse?> GetOrderDetails(int orderID)
        {
            Order? order = await _orderRepo.GetOrderDetails(orderID);
            if (order == null) return null;

            List<OrderProductResponse> orderProductResponseList = order.OrderProducts.Select(op => _mapper.Map<OrderProductResponse>(op.Product)).ToList();

            OrderDetailedResponse orderResponse = _mapper.Map<OrderDetailedResponse>(order);
            orderResponse.Products = orderProductResponseList;

            return orderResponse;
        }

        public async Task<List<OrderResponse>?> GetMyOrders(int userID)
        {
            List<Order>? orders = await _orderRepo.GetMyOrders(userID);
            if (orders == null) return null;
            return _mapper.Map<List<OrderResponse>>(orders);
        }

    }
}
