using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models;

public class CreateUserSessionRequest
{
    [Range(0, long.MaxValue)]
    public long Id { get; set; }

    [NotNull]
    [Required]
    [Length(4, 4)]
    public string? PinCode { get; set; }
}