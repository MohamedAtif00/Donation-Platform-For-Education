using Donation_Platform_For_Education.Domain.Repository.AdminRepo;

namespace Donation_Platform_For_Education.Domain.Abstarction
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }

        Task<int> save();
    }
}
