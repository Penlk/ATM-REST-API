using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Domain.ValueObjects;

public readonly struct PinCode
{
    [Length(4, 4)]
    [Required]
    [NotNull]
    public string? Value { get; }
}