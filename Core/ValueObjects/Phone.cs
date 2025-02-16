using Core.Utils;

namespace Core.ValueObjects;

public record Phone
{
    public string Value { get; init; }
    
    private Phone(string phone)
    {
        Value = phone;
    }
    
    public static Phone Create(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            throw new DomainException("Phone cannot be empty");

        if (phone.Length != 9)
            throw new DomainException("Phone must be 9 characters long");

        return new Phone(phone);
    }
}