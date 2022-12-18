using CsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SymmetricCiphers.Rc4Cipher;

namespace CsApp.Pages.Cipher;

[Authorize(Roles = RoleName.Symmetric)]
public class Rc4 : PageModel
{
    [BindProperty] public Rc4Model Rc4Model { get; set; } = null!;

    public string Message { get; private set; } = null!;

    public IActionResult OnPostEncrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new Rc4Cipher(Rc4Model.Key);
        this.Message = cipher.Encrypt(Rc4Model.Message);
        return Page();
    }

    public IActionResult OnPostDecrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new Rc4Cipher(Rc4Model.Key);
        this.Message = cipher.Decrypt(Rc4Model.Message);
        return Page();
    }
}
