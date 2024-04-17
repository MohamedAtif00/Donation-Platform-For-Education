namespace Donation_Platform_For_Education.Infarstructure.Seeding
{
    using Donation_Platform_For_Education.Infarstructure.Data;
    using Microsoft.AspNetCore.Identity;

    public class IdentitySeedData
    {
        public static async Task Initialize(ApplicationDbContext context,
        UserManager<IdentityUser<Guid>> userManager,
        RoleManager<IdentityRole<Guid>> roleManager)
        {

            context.Database.EnsureCreated();

            string asdminRole = "Admin";
            string StudentRole = "Student";
            string DonorRole = "Donor";
            string password4all = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(asdminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(asdminRole));
            }

            if (await roleManager.FindByNameAsync(StudentRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(StudentRole));
            }

            if (await roleManager.FindByNameAsync(DonorRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(DonorRole));
            }

            if (await userManager.FindByNameAsync("aa@aa.aa") == null)
            {
                var user = new IdentityUser<Guid>
                {
                    UserName = "aa@aa.aa",
                    Email = "aa@aa.aa",
                    PhoneNumber = "6902341234"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, asdminRole);
                }
            }

            if (await userManager.FindByNameAsync("mm@mm.mm") == null)
            {
                var user = new IdentityUser<Guid>
                {
                    UserName = "mm@mm.mm",
                    Email = "mm@mm.mm",
                    PhoneNumber = "1112223333"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, StudentRole);
                }
            }
        }
    }


}
