using CoreWCF;
using DTOs;
using System.Collections.Generic;

namespace CoreWCFAppServer
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        public List<ProductDTO> GetProducts();

        [OperationContract]
        public ProductDTO GetProduct(int id);

        [OperationContract]
        public void AddProduct(ProductDTO product);

        [OperationContract]
        public void UpdateProduct(int id, ProductDTO product);

        [OperationContract]
        public void DeleteProduct(ProductDTO product);
    }
}
