using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";

        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:5000/api/Products";
        }

        public async Task<IActionResult> Index()
        {
            //HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            //string strData = await response.Content.ReadAsStringAsync();
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true,
            //};
            //List<ProductDTO> products = JsonSerializer.Deserialize<List<ProductDTO>>(strData, options);
            //return View(products);
            var html = System.IO.File.ReadAllText(@"./Views/Product/Index.html");
            return base.Content(html, "text/html");
        }
    }
}
