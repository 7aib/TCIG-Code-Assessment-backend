using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
