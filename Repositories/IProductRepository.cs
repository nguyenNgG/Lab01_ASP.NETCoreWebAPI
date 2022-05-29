using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
