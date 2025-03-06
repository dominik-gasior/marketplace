using Core.Utils;

namespace Core.ValueObjects;

public record Name
{
    public string Value { get; init; }
    
    private Name(string name)
    {
        Value = name;
    }
    
    public static Name Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name cannot be empty");

        if (name.Length < 2)
            throw new DomainException("Name must be at least 2 characters long");

        return new Name(name);
    }

    public static implicit operator string(Name name) => name.Value;

    private Name()
    {

    }
}