using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Data;
using ToDoListAPI.Repository.Interfaces;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IBaseRepository<T> _repo;
        public BaseController(IBaseRepository<T> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listObj = await _repo.GetAllAsync();
            return Ok(listObj);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var obj = await _repo.GetByIdAsync(Id);
            return obj == null?NotFound():Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(T obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Id = GetId(obj);

            if (Id != 0)
                return BadRequest();

            try
            {
                obj = await _repo.AddAsync(obj);
                Id = GetId(obj);
                return Created($"v1/user/{Id}", obj);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(T obj)
        {
            try
            {
                await _repo.UpdateAsync(obj);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            try
            {
                var obj = await _repo.GetByIdAsync(Id);

                if (obj == null)
                    return NotFound();

                await _repo.DeleteAsync(obj);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private int GetId(T obj) {
            var IdObj = typeof(T).GetProperty("Id")?.GetValue(obj);

            int Id = 0;
            if (IdObj != null)
                Id = (int)IdObj;

            return Id;
        }
    }
}
