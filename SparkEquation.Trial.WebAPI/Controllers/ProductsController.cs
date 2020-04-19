using Microsoft.AspNetCore.Mvc;
using SparkEquation.Trial.WebAPI.Extensions;
using SparkEquation.Trial.WebAPI.Resources;
using SparkEquation.Trial.WebAPI.Services;
using System.Threading.Tasks;

namespace SparkEquation.Trial.WebAPI.Controllers
{
    [Route("/api/products")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllAsync()
        {
            var result = await _productService.GetAll();
            return result.MapToActionResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _productService.GetById(id);
            return result.MapToActionResult();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            var result = await _productService.SaveAsync(resource);
            return result.MapToActionResult();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            var result = await _productService.UpdateAsync(id, resource);
            return result.MapToActionResult();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return result.MapToActionResult();
        }
    }
}