using ClassicalCiphers;
using CsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CsApp.Pages.Cipher;

public class Polybius : PageModel
{
    [BindProperty] public PolybiusModel PolybiusModel { get; set; } = null!;

    public string Message { get; private set; } = null!;

    public IActionResult OnPostEncrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new PolybiusCipher(PolybiusModel.Keyword);
        this.Message = cipher.Encrypt(PolybiusModel.Message);
        return Page();
    }

    public IActionResult OnPostDecrypt(IFormCollection data)
    {
        if (!ModelState.IsValid) return Page();

        var cipher = new PolybiusCipher(PolybiusModel.Keyword);
        this.Message = cipher.Decrypt(PolybiusModel.Message);
        return Page();
    }
}
