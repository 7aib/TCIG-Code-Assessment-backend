using Microsoft.EntityFrameworkCore;
using TCIG.Domain.Entities;
using TCIG.Domain.enums;
using TCIG.Domain.Interfaces;
using TCIG.Infrastructure.Data;

namespace TCIG.Infrastructure.Repositories
{
    public class ProductRepoitory(AppDbContext dbContext) : IProductRepository
    {
        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            return await Task.FromResult(dbContext.Products.ToList());
        }

        public async Task<ProductModel?> GetProductsbyIdAsync(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ProductModel>> AddProductsAsync(ProductModel product)
        {
            product.CreatedDate = DateTime.UtcNow;

            dbContext.Products.Add(product);

            await dbContext.SaveChangesAsync();

            return await Task.FromResult(dbContext.Products.ToList());
        }

        public async Task<ProductModel> UpdateProductsAsync(ProductModel product)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.Status = product.Status;
                existingProduct.UpdatedDate = DateTime.UtcNow;
                await dbContext.SaveChangesAsync();
                return existingProduct;
            }
            throw new InvalidOperationException($"Product with Id {product.Id} not found.");
        }

        public async Task<bool> DeleteProductsAsync(int id)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct != null)
            {
                dbContext.Products.Remove(existingProduct);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        } 



    }
}
