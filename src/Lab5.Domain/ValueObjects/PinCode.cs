using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Domain.ValueObjects;

public readonly struct PinCode
{
    public PinCode(string pinCode)
    {
        Value = pinCode;
    }

    [Length(4, 4)]
    [NotNull]
    [Required]
    public string? Value { get; }
}