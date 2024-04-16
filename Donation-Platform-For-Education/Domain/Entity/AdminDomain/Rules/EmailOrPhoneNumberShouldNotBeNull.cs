using Donation_Platform_For_Education.Domain.Abstarction;

namespace Donation_Platform_For_Education.Domain.Entity.AdminDomain.Rules
{
    public class EmailOrPhoneNumberShouldNotBeNull : IBusinessRule
    {
        private readonly string _email;
        private readonly string _phoneNumber;

        public EmailOrPhoneNumberShouldNotBeNull(string phoneNumber, string email)
        {
            _phoneNumber = phoneNumber;
            _email = email;
        }

        public bool IsBroken()
        {
            if(_email == null && _phoneNumber == null) return true;
            return false;
        }
        public string Message => "Email Or Phone number Should not be null";
    }
}
