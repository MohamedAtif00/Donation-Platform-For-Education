using Ardalis.Result;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;

namespace Donation_Platform_For_Education.Application.Abstraction.ServiceAbs
{
    public interface IItemTypeService
    {
        Task<Result<ItemType>> Create(string name);
        Task<Result> Delete(Guid id);
        Task<Result<List<ItemType>>> GetAll();
        Task<Result<ItemType>> GetSingleItem(Guid id);
        Task<Result<ItemType>> Update(Guid itemTypeId, string name);
    }
}