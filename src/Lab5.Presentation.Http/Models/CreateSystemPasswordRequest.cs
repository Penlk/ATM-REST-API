using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models;

public class CreateSystemPasswordRequest
{
    [NotNull]
    [Required]
    [Length(8, 16)]
    public string? Password { get; set; }

    public Guid AdminSessionKey { get; set; }
}