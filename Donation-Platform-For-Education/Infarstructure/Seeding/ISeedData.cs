
namespace Donation_Platform_For_Education.Infarstructure.Seeding
{
    public interface ISeedData
    {
        Task InitializeAsync(IServiceProvider service);
    }
}