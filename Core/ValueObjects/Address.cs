using Core.Utils;

namespace Core.ValueObjects;

public record Address
{
    public string Street { get; init; }
    public string Number { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string ZipCode { get; init; }
    
    private Address(string street, string number, string city, string state, string zipCode)
    {
        Street = street;
        Number = number;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
    
    public static Address Create(
        string street,
        string number,
        string city,
        string state,
        string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new DomainException("Street cannot be empty");
        
        if (string.IsNullOrWhiteSpace(number))
            throw new DomainException("Number cannot be empty");

        if (string.IsNullOrWhiteSpace(city)) 
            throw new DomainException("City cannot be empty");

        if (string.IsNullOrWhiteSpace(state))
            throw new DomainException("State cannot be empty");

        if (string.IsNullOrWhiteSpace(zipCode))
            throw new DomainException("Zip code cannot be empty");

        return new Address(street, number, city, state, zipCode);
    }
}