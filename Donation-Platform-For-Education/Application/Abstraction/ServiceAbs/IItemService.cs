using Ardalis.Result;
using Donation_Platform_For_Education.Application.DTOs.Item.response;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;

namespace Donation_Platform_For_Education.Application.Abstraction.ServiceAbs
{
    public interface IItemService
    {
        Task<Result<Item>> Create(Guid itemTypeId,Guid donorId,string name, string description, int? quantity, IFormFile file, IFormFile image);
        Task<Result> Delete(Guid id);
        Task<Result<List<AllItemsResponse>>> GetAll();
        Task<Result<FileDownloadResponse>> GetFile(Guid itemId);
        Task<Result<Item>> GetSingleItem(Guid id);
        Task<Result<Item>> UpdateInfo(Guid itemId, string name,string description);
        Task<Result<Item>> UpdateQuantity(Guid itemId, int quantity);
    }
}