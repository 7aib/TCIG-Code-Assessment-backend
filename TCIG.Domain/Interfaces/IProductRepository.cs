using TCIG.Domain.Entities;

namespace TCIG.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel?> GetProductsbyIdAsync(int id);
        Task<IEnumerable<ProductModel>> AddProductsAsync(ProductModel product);
        Task<ProductModel> UpdateProductsAsync(ProductModel product);
        Task<bool> DeleteProductsAsync(int id);

    }
}
