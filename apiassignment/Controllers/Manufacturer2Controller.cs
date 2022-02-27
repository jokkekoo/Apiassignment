using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using apiassignment.Contracts;

namespace apiassignment.Controllers
{
    [Route("api/manufacturer")]
    [ApiController]
    public class Manufacturer2Controller : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepo;

        public Manufacturer2Controller(IManufacturerRepository manufacturerRepo)
        {
            _manufacturerRepo = manufacturerRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var manufacturers = await _manufacturerRepo.GetAll();
                return Ok(manufacturers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var products = await _manufacturerRepo.Get(id);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Manufacturer manufacturer)
        {
            try
            {
                var newManufacturer = await _manufacturerRepo.Post(manufacturer);
                return Ok(newManufacturer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, string name)
        {
            try
            {
                var updatedManufacturer = await _manufacturerRepo.Put(id, name);
                return Ok("Manufacturer Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteManufacturer = await _manufacturerRepo.Delete(id);
                return Ok("Product deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
