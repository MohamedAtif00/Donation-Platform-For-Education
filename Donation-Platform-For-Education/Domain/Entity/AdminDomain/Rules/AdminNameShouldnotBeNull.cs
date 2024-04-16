using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.AdminDomain.Rules
{
    public class AdminNameShouldnotBeNull : IBusinessRule
    {
        public readonly string Name;

        public AdminNameShouldnotBeNull(string name)
        {
            Name = name;
        }

        public string Message => "Admin Name Should not be null";

        public bool IsBroken()
        {
            if (Name == null) return true;
            return false;
        }
    }
}
