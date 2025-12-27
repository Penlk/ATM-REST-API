namespace Lab5.Domain.ValueObjects;

public readonly struct Money
{
    public int Value { get; }

    public Money(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);

        Value = value;
    }

    public static bool operator <(Money left, Money right) => left.Value < right.Value;

    public static bool operator >(Money left, Money right) => left.Value > right.Value;

    public static Money operator -(Money left, Money right) => new Money(left.Value - right.Value);

    public static Money operator +(Money left, Money right) => new Money(left.Value + right.Value);
}