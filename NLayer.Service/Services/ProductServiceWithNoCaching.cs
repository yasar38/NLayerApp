using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productrepository;
        private readonly IMapper _mapper;
        public ProductServiceWithNoCaching(IUnitOfWork unitOfWork, IGenericRepository<Product> repository, IProductRepository productRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _productrepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWitCategory()
        {
            var products = await _productrepository.GetProductsWitCategory();
            var productDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productDto);
        }
    }
}
