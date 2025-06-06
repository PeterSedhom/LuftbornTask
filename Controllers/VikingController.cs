using LuftbornTask.Models;
using LuftbornTask.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LuftbornTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VikingController : ControllerBase
    {
        private readonly IVikingRepository _repository;

        public VikingController(IVikingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Viking>>> Get() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Viking>> Get(string id)
        {
            var viking = await _repository.GetByIdAsync(id);
            if (viking == null) return NotFound();
            return viking;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateVikingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var viking = new Viking
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Gender = dto.Gender,
                    Rank = dto.Rank
                };
                await _repository.CreateAsync(viking);
                return CreatedAtAction(nameof(Get), new { id = viking.Id }, viking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] UpdateVikingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != dto.Id)
                return BadRequest("The id in the URL does not match the id in the body.");
            try
            {
                var existing = await _repository.GetByIdAsync(id);
                if (existing == null) return NotFound();
                var viking = new Viking
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Age = dto.Age,
                    Gender = dto.Gender,
                    Rank = dto.Rank
                };
                await _repository.UpdateAsync(id, viking);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
