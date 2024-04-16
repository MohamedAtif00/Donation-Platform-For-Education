using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.DTOs.Admin.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Donation_Platform_For_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: api/<AdminContrller>
        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> Get()
        {
            var result = await _adminService.GetAllAdmins();

            return Ok(result);
        }

        // GET api/<AdminContrller>/5
        [HttpGet("GetSingleAdmin/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _adminService.GetSingleAdmin(id);

            return Ok(result);
        }

        // POST api/<AdminContrller>
        [HttpPost("CreateNewAdmin")]
        public async Task<IActionResult> Post([FromBody] CreateNewAdminRequest value)
        {
            var result = await _adminService.Create(value.name,value.email,value.phoneNumber);

            return  Ok(result); 
        }

        // PUT api/<AdminContrller>/5
        [HttpPut("UpdateAdmine/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateAdminRequest value)
        {
            var result = await _adminService.Update(id,value.name,value.phoneNumber,value.email);

            return Ok(result);
        }

        // DELETE api/<AdminContrller>/5
        [HttpDelete("DeleteAdmine/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _adminService.DeleteAdmine(id);

            return Ok(result);
        }
    }
}
