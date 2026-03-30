
using Api_part.Model;
using Api_part.Iservice;

using Microsoft.AspNetCore.Mvc;


namespace Api_part.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryControllers : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryControllers(ICategoryService service)
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
        public async Task<IActionResult> Create(Category category)
            => Ok(await _service.Add(category));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            var updated = await _service.Update(id, category);
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