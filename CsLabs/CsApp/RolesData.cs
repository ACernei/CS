using CsApp.Data;
using CsApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CsApp;

public static class RolesData
{
    private static readonly string[] Roles = { RoleName.Classic, RoleName.Symmetric, RoleName.Asymmetric };

    public static async Task SeedRoles(IServiceProvider serviceProvider)
    {
        using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            if (!dbContext.UserRoles.Any())
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                foreach (var role in Roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

        }
    }
}
