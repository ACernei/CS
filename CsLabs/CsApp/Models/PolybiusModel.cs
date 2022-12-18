using System.ComponentModel.DataAnnotations;

namespace CsApp.Models;

public class PolybiusModel
{
    [Required]
    public string Keyword { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;
}
