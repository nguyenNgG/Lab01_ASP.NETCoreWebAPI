using DTOs;
using Repositories;
using System.Collections.Generic;

namespace CoreWCFAppServer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository = new ProductRepository();

        public void AddProduct(ProductDTO product)
        {
            repository.SaveProduct(product);
        }

        public void DeleteProduct(ProductDTO product)
        {
            repository.DeleteProduct(product);
        }

        public ProductDTO GetProduct(int id)
        {
            return repository.GetProductById(id);
        }

        public List<ProductDTO> GetProducts()
        {
            return repository.GetProducts();
        }

        public void UpdateProduct(int id, ProductDTO product)
        {
            repository.UpdateProduct(product);
        }
    }
}
