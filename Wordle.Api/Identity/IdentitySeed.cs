using Microsoft.AspNetCore.Identity;
using Wordle.Api.Data;

namespace Wordle.Api.Identity
{
    public static class IdentitySeed
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed Roles
            await SeedRolesAsync(roleManager);

            // Seed Admin User
            await SeedAdminUserAsync(userManager);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Seed Roles
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Grant))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Grant));
            }
            if (!await roleManager.RoleExistsAsync(Roles.MasterOfTheUniverse))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.MasterOfTheUniverse));
            }
        }

        private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
        {
            // Seed Admin User
            if (await userManager.FindByNameAsync("Admin@intellitect.com") == null)
            {
                AppUser user = new()
                {
                    UserName = "Admin@intellitect.com",
                    Email = "Admin@intellitect.com",
                    BirthDate = new DateTime(2021, 01, 20),
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                    await userManager.AddToRoleAsync(user, Roles.Grant);
                }
            }

            if (await userManager.FindByNameAsync("Master@intellitect.com") == null)
            {
                AppUser user = new()
                {
                    UserName = "Master@intellitect.com",
                    Email = "Master@intellitect.com",
                    BirthDate = new DateTime(2021, 09, 18),
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                    await userManager.AddToRoleAsync(user, Roles.MasterOfTheUniverse);
                }
            }

            if (await userManager.FindByNameAsync("TheTrueMasterOfTheUniverse@intellitect.com") == null)
            {
                AppUser user = new()
                {
                    UserName = "TheTrueMasterOfTheUniverse@intellitect.com",
                    Email = "TheTrueMasterOfTheUniverse@intellitect.com",
                    BirthDate = new DateTime(1987, 06, 24),
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                    await userManager.AddToRoleAsync(user, Roles.Grant);
                    await userManager.AddToRoleAsync(user, Roles.MasterOfTheUniverse);
                }
            }
        }
    }
}
