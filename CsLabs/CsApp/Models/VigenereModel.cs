using System.ComponentModel.DataAnnotations;

namespace CsApp.Models;

public class VigenereModel
{
    [Required]
    public string Keyword { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;
}
