using System.ComponentModel.DataAnnotations;

namespace CsApp.Models;

public class DesModel
{
    [Required]
    public string Key { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;
}
