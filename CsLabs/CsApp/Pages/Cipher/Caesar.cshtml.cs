using ClassicalCiphers;
using CsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CsApp.Pages.Cipher;

[Authorize(Roles = RoleName.Classic)]
public class Caesar : PageModel
{
    [BindProperty] public CaesarModel CaesarModel { get; set; } = null!;

    public string Message { get; private set; } = null!;

    public IActionResult OnPostEncrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new CaesarCipher(CaesarModel.Key);
        this.Message = cipher.Encrypt(CaesarModel.Message);
        return Page();
    }

    public IActionResult OnPostDecrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new CaesarCipher(CaesarModel.Key);
        this.Message = cipher.Decrypt(CaesarModel.Message);
        return Page();
    }
}
