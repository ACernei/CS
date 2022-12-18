using CsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SymmetricCiphers.DesCipher;

namespace CsApp.Pages.Cipher;

[Authorize(Roles = RoleName.Symmetric)]
public class Des : PageModel
{
    [BindProperty] public DesModel DesModel { get; set; } = null!;

    public string Message { get; private set; } = null!;

    public IActionResult OnPostEncrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new DesCipher(DesModel.Key);
        this.Message = cipher.Encrypt(DesModel.Message);
        return Page();
    }

    public IActionResult OnPostDecrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new DesCipher(DesModel.Key);
        this.Message = cipher.Decrypt(DesModel.Message);
        return Page();
    }
}
