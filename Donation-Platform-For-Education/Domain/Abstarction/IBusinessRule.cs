namespace Donation_Platform_For_Education.Domain.Abstarction
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
