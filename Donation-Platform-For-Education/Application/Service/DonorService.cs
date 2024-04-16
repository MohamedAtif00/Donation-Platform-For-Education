using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.DonorDomain;
using Donation_Platform_For_Education.Domain.Repository.DonorRepo;

namespace Donation_Platform_For_Education.Application.Service
{
    public class DonorService : IDonorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DonorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Donor>>> GetAll()
        {
            try
            {
                var donors = await _unitOfWork.DonorRepository.GetAll();

                if (donors == null) return Result.Error("error");

                return Result.Success(donors);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<Donor>> GetSingleDonor(Guid id)
        {
            try
            {
                var donor = await _unitOfWork.DonorRepository.GetById(DonorId.Create(id));

                if (donor == null) return Result.Error("this doner is not exist");

                return Result.Success(donor);

            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }


        public async Task<Result<Donor>> Create(string name)
        {
            try
            {
                var donorCreate = Donor.Create(name);
                var donor = await _unitOfWork.DonorRepository.Add(donorCreate);

                if (donor == null) return Result.Error("error");

                int result = await _unitOfWork.save();

                return Result.Success(donor);
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<Donor>> Update(Guid id, string name)
        {
            try
            {
                var donor = await _unitOfWork.DonorRepository.GetById(DonorId.Create(id));

                donor.Update(name);

                var update = await _unitOfWork.DonorRepository.Update(donor);

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
                var donor = await _unitOfWork.DonorRepository.GetById(DonorId.Create(id));

                if (donor == null) return Result.Error("this donor is not exist");

                await _unitOfWork.DonorRepository.Delete(donor);

                int result = await _unitOfWork.save();

                if (result == 0) return Result.Error("no change has been made");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }

        // Operation

    }
}
