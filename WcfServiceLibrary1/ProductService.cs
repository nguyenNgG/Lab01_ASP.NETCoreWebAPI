using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfMyStoreService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        public string AddProduct(Product product)
        {
            var db = new MyStoreContext();
            db.Products.Add(product);
            db.SaveChanges();
            return "added product";
        }

        public Product GetData(int id)
        {
            var db = new MyStoreContext();
            var product = db.Products.FirstOrDefault(p => p.ProductId == id);
            return product;
        }
    }
}
