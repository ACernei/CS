using ClassicalCiphers;
using CsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CsApp.Pages.Cipher;

[Authorize(Roles = RoleName.Classic)]
public class Vigenere : PageModel
{
    [BindProperty] public VigenereModel VigenereModel { get; set; } = null!;

    public string Message { get; private set; } = null!;

    public IActionResult OnPostEncrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new VigenereCipher(VigenereModel.Keyword);
        this.Message = cipher.Encrypt(VigenereModel.Message);
        return Page();
    }

    public IActionResult OnPostDecrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new VigenereCipher(VigenereModel.Keyword);
        this.Message = cipher.Decrypt(VigenereModel.Message);
        return Page();
    }
}
