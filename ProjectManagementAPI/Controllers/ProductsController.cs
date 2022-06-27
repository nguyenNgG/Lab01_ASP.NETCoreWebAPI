using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;
using ServiceReference1;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        [EnableQuery]
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts() => repository.GetProducts();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress("http://localhost:8000/WcfMyStore/ProductService");
            ProductServiceClient client = new ProductServiceClient(basicHttpBinding, address);
            Product product = await client.GetDataAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult PostProduct(ProductDTO product)
        {
            repository.SaveProduct(product);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var product = repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(product);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, ProductDTO product)
        {
            var _product = repository.GetProductById(id);
            if (_product == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(product);
            return NoContent();
        }
    }
}
