using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.DTOs.Donor.Request;
using Donation_Platform_For_Education.Application.DTOs.Item.Request;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Donation_Platform_For_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly UserManager<IdentityUser<Guid>> _userManager;


        public ItemController(IItemService itemService, UserManager<IdentityUser<Guid>> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _itemService.GetAll();



            return Ok(result);
        }
        [HttpGet("GetItemsForType/{itemTypeId}")]
        public async Task<IActionResult> GetForType(Guid itemTypeId)
        {
            var result = await _itemService.GetItemsForType(itemTypeId);

            return Ok(result);
        }


        // GET api/<ItemController>/5
        [HttpGet("GetSingleItem/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = _itemService.GetSingleItem(id).Result.Value;

            if (result == null) return Ok(result);

            var userId = result.donorId.ToString();
            IdentityUser<Guid> user = await _userManager.FindByIdAsync(userId);


            if (user == null) return NotFound();

            return Ok(Result.Success(new {result.itemId,result.itemTypeId,result.donorId,result.donationHistory,result.name,result.description,result.quantity,result.bytes,result.image,user.UserName }));
        }
        [HttpGet("GetPdf/{itemId}")]
        public async Task<IActionResult> GetFile(Guid itemId)
        {
            var result = await _itemService.GetFile(itemId);

            if (result.Errors.Count() != 0) return NotFound("this file is not exist");

            return File(result.Value.bytes,result.Value.contentType,result.Value.fileName);
            
        }

        // POST api/<ItemController>
        [HttpPost("CreateNewItem")]
        [Authorize(Roles = "Donor")]
        public async Task<IActionResult> Post([FromForm] CreateItemRequest value)
        {

            var result = await _itemService.Create(value.itemTypeId,value.userId,value.name,value.description,value.quantity,value.file,value.image);

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
