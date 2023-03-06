using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OB_APIVersionControlEjercicio.DTO;
using System.Text.Json;

namespace OB_APIVersionControlEjercicio.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public const string API_TEST_URL = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient) => _httpClient = httpClient;

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _httpClient.DefaultRequestHeaders.Clear();

            var response = await _httpClient.GetStreamAsync(API_TEST_URL);
            var productData = await JsonSerializer.DeserializeAsync<IEnumerable<Product_v2>>(response);

            if (productData != null && productData.Any())
                productData.ToList().ForEach(p => p.InternalId = Guid.NewGuid());

            return Ok(productData);
        }
    }
}
