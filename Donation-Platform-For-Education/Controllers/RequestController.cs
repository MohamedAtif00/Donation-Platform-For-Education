using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.DTOs.Request.Request;
using Donation_Platform_For_Education.Application.DTOs.Request.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Donation_Platform_For_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: api/<RequestController>
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _requestService.GetAll();

            return Ok(result);
        }
        [HttpPost("CheckRequestExist")]
        public async Task<IActionResult> CheckRequestExist([FromBody] CheckRequestExistRequest request)
        {
            var result = await _requestService.CheckRequestExist(request.userId,request.itemId);

            return Ok(result);
        }

        // GET api/<RequestController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RequestController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequest request)
        {
            var result = await _requestService.Create(request.userId,request.itemId);

            if (result.Value != null)
            {
                return Ok(Result.Success(new { result.Value.Id, result.Value.userId, result.Value.itemId.value }));

            }
            return Ok(result);

        }



        //// PUT api/<RequestController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RequestController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
