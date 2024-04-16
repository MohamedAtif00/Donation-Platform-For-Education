using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;

namespace Donation_Platform_For_Education.Application.Service
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<List<Item>>> GetAll()
        {
            try
            {
                var items = await _unitOfWork.ItemRepository.GetAll();

                if (items == null) return Result.Error("error");

                return Result.Success(items);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<Item>> GetSingleItem(Guid id)
        {
            try
            {
                var item = await _unitOfWork.ItemRepository.GetById(ItemId.Create(id));

                if (item == null) return Result.Error("this item is not exist");


                return Result.Success(item);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<Item>> Create(Guid itemTypeId,string name, string description, int? quantity)
        {
            try
            {
                var item = await _unitOfWork.ItemRepository.Add(Item.Create(ItemTypeId.Create(itemTypeId),name, description, quantity));

                if (item == null) return Result.Error("error");

                int result = await _unitOfWork.save();

                if (result == 0) return Result.Error("no changes");

                return Result.Success(item);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<Item>> UpdateInfo(Guid itemId, string name,string description)
        {
            try
            {
                var item = await _unitOfWork.ItemRepository.GetById(ItemId.Create(itemId));

                if (item == null) return Result.Error("this item is not exist");

                item.UpdateInfo(name,description);

                var update = await _unitOfWork.ItemRepository.Update(item);

                int result = await _unitOfWork.save();

                return Result.Success(update);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<Item>> UpdateQuantity(Guid itemId,int quantity)
        {
            try
            {
                var item = await _unitOfWork.ItemRepository.GetById(ItemId.Create(itemId));

                if (item == null) return Result.Error("this item is not exist");

                item.UpdateQuantity(quantity);

                var update = await _unitOfWork.ItemRepository.Update(item);

                int result = await _unitOfWork.save();

                return Result.Success(update);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result> Delete(Guid id)
        {
            try
            {
                var item = await _unitOfWork.ItemRepository.GetById(ItemId.Create(id));

                if (item == null) return Result.Error("this item is not exist");

                await _unitOfWork.ItemRepository.Delete(item);

                int result = await _unitOfWork.save();

                if (result == 0) return Result.Error("no change has been made");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }
    }
}
