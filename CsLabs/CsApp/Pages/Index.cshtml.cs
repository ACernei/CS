using CsApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CsApp.Pages;

public class IndexModel : PageModel
{
    [BindProperty] public RolesModel RolesModel { get; set; } = null!;

    private readonly SignInManager<IdentityUser> signInManager;
    private readonly UserManager<IdentityUser> userManager;
    private readonly ILogger<IndexModel> logger;

    public IndexModel(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        ILogger<IndexModel> logger)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.logger = logger;
    }

    public async Task<IActionResult> OnPostSubmitAsync(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var user = await this.userManager.FindByEmailAsync(User.Identity.Name);

        var changed = false;
        changed |= await UpdateRole(user, RolesModel.ClassicalCipher, RoleName.Classic);
        changed |= await UpdateRole(user, RolesModel.SymmetricCipher, RoleName.Symmetric);
        changed |= await UpdateRole(user, RolesModel.AsymmetricCipher, RoleName.Asymmetric);

        if (changed)
            await this.signInManager.RefreshSignInAsync(user);

        return RedirectToPage();
    }

    private async Task<bool> UpdateRole(IdentityUser user, bool willBeEnabled, string roleName)
    {
        var isEnabled = await this.userManager.IsInRoleAsync(user, roleName);
        if (willBeEnabled && !isEnabled)
        {
            await this.userManager.AddToRoleAsync(user, roleName);
            return true;
        }
        if (!willBeEnabled && isEnabled)
        {
            await this.userManager.RemoveFromRoleAsync(user, roleName);
            return true;
        }

        return false;
    }
}
