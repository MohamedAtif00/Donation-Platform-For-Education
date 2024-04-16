using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.DTOs.Donor.Request;
using Donation_Platform_For_Education.Application.DTOs.Item.Request;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Donation_Platform_For_Education.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _itemService.GetAll();

            return Ok(result);
        }

        // GET api/<ItemController>/5
        [HttpGet("GetSingleItem/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _itemService.GetSingleItem(id);

            return Ok(result);
        }

        // POST api/<ItemController>
        [HttpPost("CreateNewItem")]
        public async Task<IActionResult> Post([FromBody] CreateItemRequest value)
        {

            var result = await _itemService.Create(value.itemTypeId,value.name,value.description,value.quantity);

            return Ok(result);
        }

        // PUT api/<ItemController>/5
        [HttpPut("UpdateItemInfo/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateItemInfoRequest value)
        {
            var result = await _itemService.UpdateInfo(id, value.name,value.description);

            return Ok(result);
        }

        // PUT api/<ItemController>/5
        [HttpPut("UpdateItemQuantity/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateItemQuantityRequest value)
        {
            var result = await _itemService.UpdateQuantity(id, value.quantity);

            return Ok(result);
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("DeleteDonor/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _itemService.Delete(id);

            return Ok(result);
        }
    }
}
