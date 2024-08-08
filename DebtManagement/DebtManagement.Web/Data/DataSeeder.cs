/*using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Data
{
    public static class DataSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (!userManager.Users.Any())
            {
                var adminUser = new User
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    ClientName = "Admin User",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
*/




/*
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using DebtManagement.Web.Entities;

public static class DataSeeder
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Seed Roles
        await EnsureRoleAsync(roleManager, "Admin");
        await EnsureRoleAsync(roleManager, "Client");

        // Seed Admin User
        var adminEmail = "admin@example.com";
        var adminPassword = "Admin@123";
        await EnsureUserAsync(userManager, adminEmail, adminPassword, "Admin");

        // Seed Client User
        var clientEmail = "client@example.com";
        var clientPassword = "Client@123";
        await EnsureUserAsync(userManager, clientEmail, clientPassword, "Client");
    }

    private static async Task EnsureRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
    {
        var roleExists = await roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private static async Task EnsureUserAsync(UserManager<User> userManager, string email, string password, string role)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new User { UserName = email, Email = email, EmailConfirmed = true };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
    }
}
*/



/*
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Data;

public static class DataSeeder
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        // Seed Roles
        await EnsureRoleAsync(roleManager, "Admin");
        await EnsureRoleAsync(roleManager, "Client");

        // Seed Admin User
        var adminEmail = "admin@example.com";
        var adminPassword = "Admin@123";
        var adminUser = await EnsureUserAsync(userManager, adminEmail, adminPassword, "Admin");

        //dummy debts for the admin user
        if (!context.Debts.Any())
        {
            context.Debts.Add(new Debt
            {
                ClientId = adminUser.Id,
                DebtType = "Loan",
                DebtAmount = 10000,
                Installments = 12,
                RemainingAmount = 8000,
                EarlyClosingAmount = 7500,
                InterestRateMonthly = 1.5m,
                InterestRateYearly = 18m,
                InsuranceAmount = 200,
                CreateDate = DateTime.Now
            });

            context.Debts.Add(new Debt
            {
                ClientId = adminUser.Id,
                DebtType = "Credit Card",
                DebtAmount = 5000,
                Installments = 6,
                RemainingAmount = 3000,
                EarlyClosingAmount = 2800,
                InterestRateMonthly = 2.0m,
                InterestRateYearly = 24m,
                InsuranceAmount = 100,
                CreateDate = DateTime.Now
            });

            await context.SaveChangesAsync();
        }
    }

    private static async Task EnsureRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
    {
        var roleExists = await roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private static async Task<User> EnsureUserAsync(UserManager<User> userManager, string email, string password, string role)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new User { UserName = email, Email = email, EmailConfirmed = true };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
        return user;
    }
}
*/


using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Data;

public static class DataSeeder
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        // Seed Roles
        await EnsureRoleAsync(roleManager, "Admin");
        await EnsureRoleAsync(roleManager, "Client");

        // Seed Admin User
        var adminEmail = "admin@example.com";
        var adminPassword = "Admin@123";
        var adminUser = await EnsureUserAsync(userManager, adminEmail, adminPassword, "Admin");

        // Dummy debts for the admin user
        if (!context.Debts.Any())
        {
            var debt1 = new Debt
            {
                ClientId = adminUser.Id,
                DebtType = "Loan",
                DebtAmount = 10000,
                Installments = 12,
                RemainingAmount = 8000,
                EarlyClosingAmount = 7500,
                InterestRateMonthly = 1.5m,
                InterestRateYearly = 18m,
                InsuranceAmount = 200,
                CreateDate = DateTime.Now
            };

            var debt2 = new Debt
            {
                ClientId = adminUser.Id,
                DebtType = "Credit Card",
                DebtAmount = 5000,
                Installments = 6,
                RemainingAmount = 3000,
                EarlyClosingAmount = 2800,
                InterestRateMonthly = 2.0m,
                InterestRateYearly = 24m,
                InsuranceAmount = 100,
                CreateDate = DateTime.Now
            };

            context.Debts.AddRange(debt1, debt2);
            await context.SaveChangesAsync();

            // Dummy payments for the debts
            context.Payments.Add(new Payment
            {
                DebtId = debt1.Id,
                AmountPaid = 500m,
                PaymentDate = DateTime.Now
            });

            context.Payments.Add(new Payment
            {
                DebtId = debt1.Id,
                AmountPaid = 450m,
                PaymentDate = DateTime.Now.AddMonths(-1)
            });

            context.Payments.Add(new Payment
            {
                DebtId = debt2.Id,
                AmountPaid = 1000m,
                PaymentDate = DateTime.Now
            });

            context.Payments.Add(new Payment
            {
                DebtId = debt2.Id,
                AmountPaid = 800m,
                PaymentDate = DateTime.Now.AddMonths(-1)
            });

            await context.SaveChangesAsync();
        }
    }

    private static async Task EnsureRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
    {
        var roleExists = await roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private static async Task<User> EnsureUserAsync(UserManager<User> userManager, string email, string password, string role)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new User { UserName = email, Email = email, EmailConfirmed = true };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
        return user;
    }
}
