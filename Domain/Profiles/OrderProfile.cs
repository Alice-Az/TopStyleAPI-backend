using AutoMapper;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.Order;

namespace TopStyleAPI.Domain.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<OrderRequest, Order>();        
            CreateMap<Order, OrderResponse>();
            CreateMap<Order, OrderDetailedResponse>();
        }
    }
}
