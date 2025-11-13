using CodebridgeTest.BusinessLogic.Services.Interfaces;
using CodebridgeTest.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodebridgeTest.Controllers
{
    [ApiController]
    [Route("")]
    public class DogsController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogsController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Dogshouseservice.Version1.0.1");

        [HttpGet("dogs")]
        public async Task<IActionResult> GetDogs(string? attribute = null, string? order = "asc", int pageNumber = 1, int pageSize = 10)
        {
            var dogs = await _dogService.GetDogsAsync(attribute, order, pageNumber, pageSize);
            return Ok(dogs);
        }

        [HttpPost("dog")]
        public async Task<IActionResult> CreateDog([FromBody] Dog dog)
        {
            var result = await _dogService.CreateDogAsync(dog);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(dog);
        }
    }
}
