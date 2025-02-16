using System.Globalization;

namespace Core.ValueObjects;

public record PositiveNumber
{
    private decimal Value { get; }

    public PositiveNumber(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Number cannot be negative.");
        }

        Value = value;
    }

    public static implicit operator decimal(PositiveNumber positiveNumber) => positiveNumber.Value;

    public static implicit operator PositiveNumber(decimal value) => new(value);

    public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
}