using DTOs;
using System.Collections.Generic;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(ProductDTO product);
        ProductDTO GetProductById(int id);
        void DeleteProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        List<CategoryDTO> GetCategories();
        List<ProductDTO> GetProducts();
    }
}
