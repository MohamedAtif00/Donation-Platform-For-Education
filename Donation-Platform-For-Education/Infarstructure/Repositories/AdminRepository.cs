using Donation_Platform_For_Education.Domain.Entity.AdminDomain;
using Donation_Platform_For_Education.Domain.Repository.AdminRepo;
using Donation_Platform_For_Education.Infarstructure.Data;
using Donation_Platform_For_Education.Infarstructure.DomainConfig;

namespace Donation_Platform_For_Education.Infarstructure.Repositories
{
    public class AdminRepository : GenericRepository<Admin, AdminId>, IAdminRepository
    {
        public AdminRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
