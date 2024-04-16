using AutoMapper;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.Order;
using TopStyleAPI.Domain.Models.Product;

namespace TopStyleAPI.Domain.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, OrderProductResponse>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
