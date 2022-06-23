using System;
using System.Threading.Tasks;
using ServiceReference1;

namespace CoreWCFAppConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new ProductServiceClient(ProductServiceClient.EndpointConfiguration.BasicHttpBinding_IProductService, "http://localhost:8000/ProductService/basichttp");

            try
            {
                //Console.ReadLine();
                var product = await client.GetProductAsync(1);
                Console.Write(product.ProductName);
                //foreach (var product in products)
                //{
                //    Console.WriteLine(product.ProductName);
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} {e.StackTrace}");
            }
            finally
            {
                client.Close();
            }
        }
    }
}
