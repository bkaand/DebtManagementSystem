using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using DebtManagement.Web.Models;

namespace DebtManagement.Web.Data
{
    public static class DataSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin", "Client", "Company" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            // Admin User
            var adminUser = new User
            {
                UserName = "admin@debtmanagement.com",
                Email = "admin@debtmanagement.com",
                ClientName = "Admin"
            };

            if (userManager.Users.All(u => u.Id != adminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(adminUser, "Admin@123");
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Client User
            var clientUser = new User
            {
                UserName = "client@debtmanagement.com",
                Email = "client@debtmanagement.com",
                ClientName = "Client"
            };

            if (userManager.Users.All(u => u.Id != clientUser.Id))
            {
                var user = await userManager.FindByEmailAsync(clientUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(clientUser, "Client@123");
                    await userManager.AddToRoleAsync(clientUser, "Client");
                }
            }

            // Company User
            var companyUser = new User
            {
                UserName = "company@debtmanagement.com",
                Email = "company@debtmanagement.com",
                ClientName = "Company"
            };

            if (userManager.Users.All(u => u.Id != companyUser.Id))
            {
                var user = await userManager.FindByEmailAsync(companyUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(companyUser, "Company@123");
                    await userManager.AddToRoleAsync(companyUser, "Company");
                }
            }
        }
    }
}
