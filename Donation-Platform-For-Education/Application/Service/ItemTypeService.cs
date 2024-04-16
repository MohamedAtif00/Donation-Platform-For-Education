using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;

namespace Donation_Platform_For_Education.Application.Service
{
    public class ItemTypeService : IItemTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<ItemType>>> GetAll()
        {
            try
            {
                var ItemType = await _unitOfWork.ItemTypeRepository.GetAll();

                if (ItemType == null) return Result.Error("error");

                return Result.Success(ItemType);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<ItemType>> GetSingleItem(Guid id)
        {
            try
            {
                var ItemType = await _unitOfWork.ItemTypeRepository.GetById(ItemTypeId.Create(id));

                if (ItemType == null) return Result.Error("this item is not exist");


                return Result.Success(ItemType);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }
        
        public async Task<Result<ItemType>> Create(string name)
        {
            try
            {
                var itemType = await _unitOfWork.ItemTypeRepository.Add(ItemType.Create(name));

                if (itemType == null) return Result.Error("error");

                int result = await _unitOfWork.save();

                if (result == 0) return Result.Error("no changes");

                return Result.Success(itemType);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<ItemType>> Update(Guid itemTypeId, string name)
        {
            try
            {
                var itemType = await _unitOfWork.ItemTypeRepository.GetById(ItemTypeId.Create(itemTypeId));

                if (itemType == null) return Result.Error("this item is not exist");

                itemType.Update(name);

                var update = await _unitOfWork.ItemTypeRepository.Update(itemType);

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
                var itemType = await _unitOfWork.ItemTypeRepository.GetById(ItemTypeId.Create(id));

                if (itemType == null) return Result.Error("this item is not exist");

                await _unitOfWork.ItemTypeRepository.Delete(itemType);

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
