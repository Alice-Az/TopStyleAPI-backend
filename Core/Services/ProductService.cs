using AutoMapper;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.Product;

namespace TopStyleAPI.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ProductResponse?> GetProductyId(int productID)
        {
            Product? product = await _productRepo.GetProductById(productID);
            if (product == null) return null;
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<List<ProductResponse>?> GetProducts(string input)
        {
            List<Product>? products = await _productRepo.GetProducts(input);
            if (products == null) return null;

            List<ProductResponse> responses = _mapper.Map<List<ProductResponse>>(products);
            return responses;
        }

    }
}
