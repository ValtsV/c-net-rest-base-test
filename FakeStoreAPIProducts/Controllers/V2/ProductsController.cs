using FakeStoreAPIProducts.DTOs.V2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FakeStoreAPIProducts.Controllers.V2
{
    [ApiVersion("2.0")]
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

        [MapToApiVersion("2.0")]
        [HttpGet("GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var products = await JsonSerializer.DeserializeAsync<Product[]>(response);

            return Ok(products);
        }
    }
}
