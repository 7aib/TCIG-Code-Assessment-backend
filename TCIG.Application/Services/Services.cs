
using AutoMapper;
using TCIG.Application.DTOs;
using TCIG.Domain.Interfaces;
using TCIG.Domain.Entities;
using TCIG.Application.Interfaces;

namespace TCIG.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductsbyIdAsync(id);
            return product != null ? _mapper.Map<ProductDto>(product) : null;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<ProductModel>(createProductDto);
            var createdProduct = await _productRepository.AddProductsAsync(product);
            return _mapper.Map<ProductDto>(createdProduct);
        }

        public async Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var existingProduct = await _productRepository.GetProductsbyIdAsync(id);
            if (existingProduct == null)
                return null;

            _mapper.Map(updateProductDto, existingProduct);
            existingProduct.UpdatedDate = DateTime.UtcNow;

            var updatedProduct = await _productRepository.UpdateProductsAsync(existingProduct);
            return _mapper.Map<ProductDto>(updatedProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductsAsync(id);
        }
    }
}
