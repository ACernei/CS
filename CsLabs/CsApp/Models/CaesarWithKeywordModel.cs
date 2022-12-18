using System.ComponentModel.DataAnnotations;

namespace CsApp.Models;

public class CaesarWithKeywordModel
{
    [Required]
    public int Key { get; set; }

    [Required]
    public string Keyword { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;
}
