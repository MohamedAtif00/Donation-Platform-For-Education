using Donation_Platform_For_Education.Domain.Abstarction;
using Donation_Platform_For_Education.Domain.Entity.AdminDomain.Rules;

namespace Donation_Platform_For_Education.Domain.Entity.AdminDomain
{
    public class Admin : Entity<AdminId>
    {

        private Admin(AdminId id,string name) : base(id)
        {
            this.CheckRule(new AdminNameShouldnotBeNull(name));
            this.name = name;
        }

        public string name { get;private set; }
        
        public AdminContactInfo contactInfo { get; private set; }

        public static Admin Create(string name)
        {
            
            return new(AdminId.CreateUnque(),name);
        }

        public void Update(string name,string phoneNumber,string email)
        {
            this.name = name;
            UpdateContactInfo(phoneNumber, email);
        }

        public void AddContactInfo(string phoneNumber,string email)
        { 
            contactInfo = AdminContactInfo.Create(phoneNumber, email);
        }

        public void UpdateContactInfo(string phoneNumber, string email)
        {
            contactInfo = AdminContactInfo.Create(phoneNumber,email);
        }
    }
}
