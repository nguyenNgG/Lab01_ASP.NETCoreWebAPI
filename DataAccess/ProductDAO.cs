using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var context = new MyStoreContext())
                {
                    products = context.Products.ToList();
                }
            }
            catch
            {
                throw;
            }
            return products;
        }

        public static Product FindProductById(int productId)
        {
            Product dto = new Product();
            try
            {
                using (var context = new MyStoreContext())
                {
                    dto = context.Products.SingleOrDefault(x => x.ProductId == productId);
                }
            }
            catch
            {
                throw;
            }
            return dto;
        }

        public static void SaveProduct(Product product)
        {
            try
            {
                using (var context = new MyStoreContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new MyStoreContext())
                {
                    context.Entry<Product>(product).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new MyStoreContext())
                {
                    var _product = context.Products.SingleOrDefault(x => x.ProductId == product.ProductId);
                    context.Products.Remove(_product);
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
