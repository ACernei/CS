using System.ComponentModel.DataAnnotations;

namespace CsApp.Models;

public class CaesarModel
{
    [Required]
    public int Key { get; set; }

    [Required]
    public string Message { get; set; } = null!;
}
