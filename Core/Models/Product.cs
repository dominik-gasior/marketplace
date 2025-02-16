using Core.ValueObjects;

namespace Core.Models;

public class Product
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Name Name { get; init; }
    public Unit Unit { get; init; } = Unit.Unknown;
    public Category Category { get; init; } = Category.Unknown;
}