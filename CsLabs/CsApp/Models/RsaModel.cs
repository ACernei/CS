using System.ComponentModel.DataAnnotations;

namespace CsApp.Models;

public class RsaModel
{
    [Required]
    public int P { get; set; }

    [Required]
    public int Q { get; set; }

    [Required]
    public string Message { get; set; } = null!;
}
