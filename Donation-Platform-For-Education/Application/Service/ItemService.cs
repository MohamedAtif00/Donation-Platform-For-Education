using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.DTOs.Item;
using Donation_Platform_For_Education.Application.DTOs.Item.response;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.ItemTypeDomain;
using Microsoft.AspNetCore.Mvc;

namespace Donation_Platform_For_Education.Application.Service
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<List<AllItemsResponse>>> GetAll()
        {
            try
            {
                var items = await _unitOfWork.ItemRepository.GetAll();

                List<AllItemsResponse> allItems = new();

                foreach (var item in items)
                {
                    FileResponse? file = null;
                    FileResponse? image = null;

                    AllItemsResponse allItem;

                    if (item.bytes != null)
                    {
                        file = new FileResponse(item.bytes, item.name,"application/pdf");
                    }

                    if (item.image != null)
                    {
                        image = new FileResponse(item.image,item.name,"image/jpeg");
                    }

                    allItems.Add(new AllItemsResponse(item.Id.value,
                                                       item.itemTypeId.value,
                                                       item.donorId,
                                                       item.name,
                                                       item.description,
                                                       item.quantity,
                                                       image));
                }

                return Result.Success(allItems);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("System error");
            }
        }

        public async Task<Result<List<AllItemsResponse>>> GetItemsForType(Guid itemTypeId)
        {
            try
            {
                var items = await _unitOfWork.ItemRepository.GetItemsForType(ItemTypeId.Create(itemTypeId));

                if (items == null) return Result.Error("Error : this list is not exist");

                List<AllItemsResponse> allItems = new();

                foreach (var item in items)
                {
                    FileResponse? file = null;
                    FileResponse? image = null;

                    AllItemsResponse allItem;

                    if (item.bytes != null)
                    {
                        file = new FileResponse(item.bytes, item.name, "application/pdf");
                    }

                    if (item.image != null)
                    {
                        image = new FileResponse(item.image, item.name, "image/jpeg");
                    }

                    allItems.Add(new AllItemsResponse(item.Id.value,
                                                       item.itemTypeId.value,
                                                       item.donorId,
                                                       item.name,
                                                       item.description,
                                                       item.quantity,
                                                       image));
                }

                return Result.Success(allItems);
            }catch (Exception ex)
            {
                return Result.CriticalError("System error");
            }
        }



        public async Task<Result<GetSingleItemResponse>> GetSingleItem(Guid id)
        {
            try
            {
                var item = await _unitOfWork.ItemRepository.GetById(ItemId.Create(id));

                if (item == null) return Result.Error("this item is not exist");


                return Result.Success(new GetSingleItemResponse(item.Id.value,item.itemTypeId.value,item.donorId,item.name,item.DonationHistory,item.description,item.quantity,item.bytes,item.image));
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<FileDownloadResponse>> GetFile(Guid itemId)
        {
            try { 
                 var item = await _unitOfWork.ItemRepository.GetById(ItemId.Create(itemId));

                if (item == null) return Result.Error("this file is not exist");

                var response = new FileDownloadResponse(item.bytes,item.name,"application/pdf");

                return Result.Success(response);    
            }catch (Exception ex)
            {

                return Result.CriticalError("system Error");
            }
        }

        public async Task<Result<Item>> Create(Guid itemTypeId,Guid donorId,string name, string description, int? quantity, IFormFile? file,IFormFile? image)
        {
            try
            {
                byte[]? byteFile = null;
                byte[]? byteImage = null;

                if (file != null)
                    byteFile = ConvertIFormFileToByteArray(file);

                if (image != null)
                    byteImage = ConvertIFormFileToByteArray(image);

                var item = await _unitOfWork.ItemRepository.Add(Item.Create(ItemTypeId.Create(itemTypeId),donorId,name, description, quantity,byteFile,byteImage));

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

        private byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        
    }
}
