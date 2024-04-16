using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.DTOs.Donor.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Donation_Platform_For_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _service;

        public DonorController(IDonorService service)
        {
            _service = service;
        }

        // GET: api/<DonorController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAll();

            return Ok(result);
        }

        // GET api/<DonorController>/5
        [HttpGet("GetSingleDonor/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.GetSingleDonor(id);

            return Ok(result);
        }

        // POST api/<DonorController>
        [HttpPost("CreateNewDonor")]
        public async Task<IActionResult> Post([FromBody] CreateDonorRequest value)
        {
            var result = await _service.Create(value.name);

            return Ok(result);
        }

        // PUT api/<DonorController>/5
        [HttpPut("UpdateDonor/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateDonorRequest value)
        {
            var result = await _service.Update(id, value.name);

            return Ok(result);
        }

        // DELETE api/<DonorController>/5
        [HttpDelete("DeleteDonor/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);

            return Ok(result);
        }
    }
}
