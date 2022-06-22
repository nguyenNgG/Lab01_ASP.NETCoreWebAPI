﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;

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
        public IActionResult GetProduct(int id)
        {
            return NoContent();
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
