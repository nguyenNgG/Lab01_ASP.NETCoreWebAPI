using DTOs;
using Grpc.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductGrpcService.Services
{
    public class ProductCRUDService : ProductCRUD.ProductCRUDBase
    {
        private Repositories.IProductRepository repository = new Repositories.ProductRepository();

        /*
           rpc GetAll(Empty) returns (Products);
           rpc Get(ProductId) returns (Product);
           rpc Add(Product) returns (Empty);
           rpc Update(Product) returns (Empty);
           rpc Delete(ProductId) returns (Empty);
         */

        public override Task<Products> GetAll(Empty requestData, ServerCallContext context)
        {
            Products response = new Products();
            var query = from product in repository.GetProducts()
                        select new Product
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            CategoryId = (int)product.CategoryId,
                            UnitPrice = (decimal)product.UnitPrice,
                            UnitsInStock = (int)product.UnitsInStock
                        };
            response.Items.AddRange(query.ToArray());
            return Task.FromResult(response);
        }

        public override Task<Empty> Add(Product request, ServerCallContext context)
        {
            repository.SaveProduct(new ProductDTO
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                CategoryId = request.CategoryId,
                UnitPrice = request.UnitPrice,
                UnitsInStock = (short)request.UnitsInStock
            });
            return Task.FromResult(new Empty());
        }
    }
}
