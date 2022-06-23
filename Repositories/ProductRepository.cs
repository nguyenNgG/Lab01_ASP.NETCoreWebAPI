using BusinessObjects;
using DataAccess;
using DTOs;
using Repositories.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductDTO GetProductById(int id) => MyStoreMapper<Product, ProductDTO>.Map(ProductDAO.FindProductById(id));
        public void SaveProduct(ProductDTO product) => ProductDAO.SaveProduct(MyStoreMapper<ProductDTO, Product>.Map(product));
        public void UpdateProduct(ProductDTO product) => ProductDAO.UpdateProduct(MyStoreMapper<ProductDTO, Product>.Map(product));
        public void DeleteProduct(ProductDTO product) => ProductDAO.DeleteProduct(MyStoreMapper<ProductDTO, Product>.Map(product));
        public List<CategoryDTO> GetCategories() => MyStoreMapper<Category, CategoryDTO>.MapList(CategoryDAO.GetCategories().ToList()).ToList();
        public List<ProductDTO> GetProducts() => MyStoreMapper<Product, ProductDTO>.MapList(ProductDAO.GetProducts().ToList()).ToList();


    }
}
