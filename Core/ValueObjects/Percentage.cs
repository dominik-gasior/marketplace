using Core.Utils;

namespace Core.ValueObjects;

public record Percentage
{
    public decimal Value { get; init; }

    private Percentage(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Percentage value must be greater than or equal to 0.");

        Value = value;
    }

    public static Percentage FromDecimal(decimal value)
        => new(value);

    public static Percentage FromFraction(decimal value)
        => new(value * 100);

    public static Percentage FromString(string value)
    {
        if (decimal.TryParse(value, out var result))
            return new Percentage(result);

        throw new DomainException("Invalid percentage value.");
    }

    public override string ToString() => $"{Value}%";

    public static implicit operator decimal(Percentage percentage)
        => percentage.Value;

    public static implicit operator Percentage(decimal value)
        => new(value);

    private Percentage()
    {

    }
}