using CsApp.Data;
using CsApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CsApp;

public static class RolesData
{
    private static readonly string[] Roles = { RoleName.Classic, RoleName.Symmetric, RoleName.Asymmetric };

    public static async Task SeedRoles(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
            await dbContext.Database.MigrateAsync();

        if (dbContext.UserRoles.Any())
            return;

        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
