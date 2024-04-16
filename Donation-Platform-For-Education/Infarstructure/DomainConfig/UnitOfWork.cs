using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Repository.AdminRepo;
using Donation_Platform_For_Education.Infarstructure.Data;

namespace Donation_Platform_For_Education.Infarstructure.DomainConfig
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(IAdminRepository adminRepository, ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            AdminRepository = adminRepository;
        }



        public IAdminRepository AdminRepository { get;  }

        public async Task<int> save()
        {
           return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
