namespace Donation_Platform_For_Education.Infarstructure.Seeding
{
    using Microsoft.AspNetCore.Identity;

    public class SeedData
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedData(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            // Seed custom roles (if needed)
            await SeedRolesAsync();
        }

        private async Task SeedRolesAsync()
        {
            // Check if custom roles exist
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                // Create Admin role
                var adminRole = new IdentityRole("Admin");
                await _roleManager.CreateAsync(adminRole);
            }

            if (!await _roleManager.RoleExistsAsync("Donor"))
            {
                // Create Moderator role
                var moderatorRole = new IdentityRole("Donor");
                await _roleManager.CreateAsync(moderatorRole);
            }

            if (!await _roleManager.RoleExistsAsync("Student"))
            {
                // Create Moderator role
                var moderatorRole = new IdentityRole("Student");
                await _roleManager.CreateAsync(moderatorRole);
            }
            // Add other custom roles as needed
        }
    }

}
