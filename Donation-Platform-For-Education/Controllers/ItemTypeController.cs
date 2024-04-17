using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.DTOs.Item.Request;
using Donation_Platform_For_Education.Application.DTOs.ItemType.Request;
using Donation_Platform_For_Education.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Donation_Platform_For_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        private readonly IItemTypeService _itemTypeService;

        public ItemTypeController(IItemTypeService itemTypeService)
        {
            _itemTypeService = itemTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _itemTypeService.GetAll();

            return Ok(result);
        }

        // GET api/<ItemController>/5
        [HttpGet("GetSingleItemType/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _itemTypeService.GetSingleItem(id);

            return Ok(result);
        }

        // POST api/<ItemController>
        [HttpPost("CreateNewItemType")]
        public async Task<IActionResult> Post([FromBody] CreateItemTypeRequest value)
        {

            var result = await _itemTypeService.Create(value.name);

            return Ok(result);
        }

        // PUT api/<ItemController>/5
        [HttpPut("UpdateItemType/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateItemTypeRequest value)
        {
            var result = await _itemTypeService.Update(id,value.name);

            return Ok(result);
        }


        // DELETE api/<ItemController>/5
        [HttpDelete("DeleteItemType/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _itemTypeService.Delete(id);

            return Ok(result);
        }
    }
}
