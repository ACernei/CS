using ClassicalCiphers;
using CsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CsApp.Pages.Cipher;

[Authorize(Roles = RoleName.Classic)]
public class CaesarWithKeyword : PageModel
{
    [BindProperty] public CaesarWithKeywordModel CaesarWithKeywordModel { get; set; } = null!;

    public string Message { get; private set; } = null!;

    public IActionResult OnPostEncrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new CaesarCipherWithKeyword(CaesarWithKeywordModel.Key, CaesarWithKeywordModel.Keyword);
        this.Message = cipher.Encrypt(CaesarWithKeywordModel.Message);
        return Page();
    }

    public IActionResult OnPostDecrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new CaesarCipherWithKeyword(CaesarWithKeywordModel.Key, CaesarWithKeywordModel.Keyword);
        this.Message = cipher.Decrypt(CaesarWithKeywordModel.Message);
        return Page();
    }
}
