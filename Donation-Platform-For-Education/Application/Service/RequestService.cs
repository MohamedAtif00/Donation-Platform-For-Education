using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Application.DTOs.Request.Response;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;
using Donation_Platform_For_Education.Domain.Repository.RequestRepo;
using Microsoft.AspNetCore.Identity;

namespace Donation_Platform_For_Education.Application.Service
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public RequestService(IUnitOfWork unitOfWork, UserManager<IdentityUser<Guid>> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Result<List<RequestInfoResponse>>> GetAll()
        {
            try {
                List<Request> requests = await _unitOfWork.RequestRepository.GetAll();
                List<RequestInfoResponse> result = new();
                foreach (var request in requests)
                {
                    var username = await _userManager.FindByIdAsync(request.userId.ToString());
                    var itemName = await _unitOfWork.ItemRepository.GetById(request.itemId);

                    result.Add(new RequestInfoResponse(username.UserName,username.Email,itemName.name));
                }


                if (requests == null) return Result.Error("error");

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.CriticalError("system Error");
            }
        }

        

        public async Task<Result<Request>> Create(Guid userId,Guid itemId)
        {
            try
            {
                var requestExist = await _unitOfWork.RequestRepository.CheckRequestExist(userId,ItemId.Create(itemId));

                if (requestExist.Value)
                {
                    return Result.Error("This request in process");
                }

                var request = Request.Create(userId, ItemId.Create(itemId));

                var result = await _unitOfWork.RequestRepository.Add(request);

                if (result == null) return Result.Error("error");

                int save = await _unitOfWork.save();

                if (save == 0) return Result.Error("save Error");

                return Result.Success(result);

            }catch (Exception ex)
            {
                return Result.CriticalError("System Error");
            }
        }

        public async Task<Result<bool>> CheckRequestExist(Guid userId,Guid itemId)
        {
            try {
                var result = await _unitOfWork.RequestRepository.CheckRequestExist(userId, ItemId.Create(itemId));

                return Result.Success(result);
            } catch (Exception ex)
            {
                return Result.Error("system error");
            }
        }

       // public async Task<Result<RequestInfoResponse>> GetAllRqeq
    }
}
