using Microsoft.AspNetCore.Mvc;
using Api_part.Iservice;
using Api_part.Model; // or the correct namespace where Product is defined
namespace Api_part.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductControllers : ControllerBase
    {
        private readonly IProductService _service;

        public ProductControllers(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
            => Ok(await _service.Add(product));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            var updated = await _service.Update(id, product);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}