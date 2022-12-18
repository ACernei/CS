using AsymmetricCiphers;
using CsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CsApp.Pages.Cipher;

[Authorize(Roles = RoleName.Asymmetric)]
public class Rsa : PageModel
{
    [BindProperty] public RsaModel RsaModel { get; set; } = null!;

    public string Message { get; private set; } = null!;

    public IActionResult OnPostEncrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new RsaCipher(RsaModel.P, RsaModel.Q);
        this.Message = cipher.Encrypt(RsaModel.Message);
        return Page();
    }

    public IActionResult OnPostDecrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new RsaCipher(RsaModel.P, RsaModel.Q);
        this.Message = cipher.Decrypt(RsaModel.Message);
        return Page();
    }
}
