using ClinicMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ClinicMS.Infrastructure.Data.SeedData
{
  public static class IdentityDataInitializer
  {
    public static async Task SeedData(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
      // ============================================
      // 1. Seed Admin Role
      // ============================================

      const string adminRole = "Admin";

      if (!await roleManager.RoleExistsAsync(adminRole))
      {
        var role = new ApplicationRole
        {
          Id = Guid.NewGuid().ToString(),
          Name = adminRole
        };

        var roleResult = await roleManager.CreateAsync(role);

        if (!roleResult.Succeeded)
        {
          throw new Exception(
              $"Failed to create role '{adminRole}': " +
              string.Join(", ",
                  roleResult.Errors.Select(e => e.Description)));
        }
      }


      // ============================================
      // 2. Seed Admin User
      // ============================================

      const string adminEmail = "admin@clinicms.com";
      const string adminPassword = "Admin@12345";

      var adminUser = await userManager.FindByEmailAsync(adminEmail);

      if (adminUser == null)
      {
        adminUser = new ApplicationUser
        {

          Id = Guid.NewGuid().ToString(),
          UserName = adminEmail,
          Email = adminEmail,

          FullName = "System Administrator",
          IsActive = true,
          CreatedOn = DateTime.UtcNow,

          EmailConfirmed = true
        };

        var userResult = await userManager.CreateAsync(
            adminUser,
            adminPassword);

        if (!userResult.Succeeded)
        {
          throw new Exception(
              $"Failed to create admin user: " +
              string.Join(", ",
                  userResult.Errors.Select(e => e.Description)));
        }
      }


      // ============================================
      // 3. Assign Admin Role to Admin User
      // ============================================

      if (!await userManager.IsInRoleAsync(adminUser, adminRole))
      {
        var roleResult = await userManager.AddToRoleAsync(
            adminUser,
            adminRole);

        if (!roleResult.Succeeded)
        {
          throw new Exception(
              $"Failed to assign role '{adminRole}' " +
              $"to user '{adminEmail}': " +
              string.Join(", ",
                  roleResult.Errors.Select(e => e.Description)));
        }
      }
    }
  }
}