
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

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Price = p.Price,
                Stock = p.Stock,
                Status = p.Status,
                Image = p.Image,
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate
            });
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductsbyIdAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                Status = product.Status,
                Image = product.Image,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate
            };
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new ProductModel
            {
                ProductName = createProductDto.ProductName,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                Status = createProductDto.Status,
                Image = createProductDto.Image
            };

            await _productRepository.AddProductsAsync(product);

            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                Status = product.Status,
                Image = product.Image,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate
            };
        }

        public async Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetProductsbyIdAsync(id);
            if (product == null) return null;

            product.ProductName = updateProductDto.ProductName;
            product.Price = updateProductDto.Price;
            product.Stock = updateProductDto.Stock;
            product.Status = updateProductDto.Status;
            product.Image = updateProductDto.Image;

            await _productRepository.UpdateProductsAsync(product);

            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                Status = product.Status,
                Image = product.Image,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetProductsbyIdAsync(id);
            if (product == null) return false;

            await _productRepository.DeleteProductsAsync(id);
            return true;
        }
    
}
}
