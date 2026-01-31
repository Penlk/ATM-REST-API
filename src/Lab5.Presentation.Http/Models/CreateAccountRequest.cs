using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models;

public class CreateAccountRequest
{
    public Guid SessionId { get; set; }

    [NotNull]
    [Required]
    [Length(4, 4)]
    public string? PinCode { get; set; }
}