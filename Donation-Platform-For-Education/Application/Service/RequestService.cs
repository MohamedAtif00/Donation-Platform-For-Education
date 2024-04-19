using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.ItemDomain;
using Donation_Platform_For_Education.Domain.Entity.RequestDomain;
using Donation_Platform_For_Education.Domain.Repository.RequestRepo;

namespace Donation_Platform_For_Education.Application.Service
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Request>>> GetAll()
        {
            try {
                List<Request> requests = await _unitOfWork.RequestRepository.GetAll();

                if (requests == null) return Result.Error("error");

                return Result.Success(requests);
            }catch (Exception ex)
            {
                return Result.CriticalError("system Error");
            }
        }

        

        public async Task<Result<Request>> Create(Guid userId,Guid itemId)
        {
            try
            {
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
    }
}
