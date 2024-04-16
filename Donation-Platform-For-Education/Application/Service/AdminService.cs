using Ardalis.Result;
using Donation_Platform_For_Education.Application.Abstraction.ServiceAbs;
using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.AdminDomain;

namespace Donation_Platform_For_Education.Application.Service
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Admin>>> GetAllAdmins()
        {
            try
            {
                var admin = await _unitOfWork.AdminRepository.GetAll();

                if (admin == null) return Result.Error("error");

                return Result.Success(admin);
            }
            catch (Exception ex)
            {
                return Result.Error("system error");
            }
        }

        public async Task<Result<Admin>> GetSingleAdmin(Guid id)
        {
            try
            {
                var admin = await _unitOfWork.AdminRepository.GetById(AdminId.Create(id));

                if (admin == null) return Result.NotFound("this admin is not exist");

                return Result.Success(admin);


            }
            catch (Exception ex)
            {

                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<Admin>> Create(string name, string email, string phoneNumber)
        {
            try
            {
                var admin = Admin.Create(name);

                admin.AddContactInfo(email, phoneNumber);

                var result = await _unitOfWork.AdminRepository.Add(admin);


                int effectedRows = await _unitOfWork.save();

                if (effectedRows != 0)
                {
                    return Result.Success(admin);
                }
                else
                {
                    return Result.Error("Error");
                }

            }
            catch (Exception ex)
            {

                return Result.CriticalError("system error");
            }
        }

        public async Task<Result<Admin>> Update(Guid id, string name, string phoneNumber, string email)
        {
            try
            {

                var admin = await _unitOfWork.AdminRepository.GetById(AdminId.Create(id));

                if (admin == null) return Result.NotFound("this admin is not exist");

                admin.Update(name, phoneNumber, email);

                var resultUpdate = await _unitOfWork.AdminRepository.Update(admin);

                int result = await _unitOfWork.save();

                if (result != 0)
                {
                    return Result.Success(admin);
                }
                else
                {
                    return Result.Error("error");
                }

            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }

        }

        public async Task<Result> DeleteAdmine(Guid id)
        {
            try
            {
                var admin = await _unitOfWork.AdminRepository.GetById(AdminId.Create(id));

                if (admin == null) return Result.NotFound("this admin is not exist");

                await _unitOfWork.AdminRepository.Delete(admin);

                int result = await _unitOfWork.save();

                if (result != 0)
                {
                    return Result.Success();
                }
                else
                {
                    return Result.Error("error");
                }
            }
            catch (Exception ex)
            {
                return Result.CriticalError("system error");
            }
        }


    }
}
    