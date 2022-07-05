using FakeStoreAPIProducts.DTOs.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FakeStoreAPIProducts.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string ApiTestURL = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            var response = await _httpClient.GetStreamAsync(ApiTestURL);
            Console.WriteLine(response);

            var products = await JsonSerializer.DeserializeAsync<Product[]>(response);


            return Ok(products);
        }
    }
}
