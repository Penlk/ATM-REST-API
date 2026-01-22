using System.ComponentModel.DataAnnotations;

namespace Lab5.Domain.ValueObjects;

public readonly struct PinCode : IEquatable<PinCode>
{
    public PinCode(string pinCode)
    {
        Value = pinCode;
    }

    [Length(4, 4)]
    [Required]
    public string Value { get; }

    public bool Equals(PinCode other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is PinCode other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode(StringComparison.Ordinal);
    }

    public static bool operator ==(PinCode left, PinCode right) => left.Value == right.Value;

    public static bool operator !=(PinCode left, PinCode right) => left.Value != right.Value;
}
