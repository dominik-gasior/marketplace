using Core.Utils;

namespace Core.ValueObjects;

public record Email
{
    public string Value { get; init; }
    
    private Email(string email)
    {
        Value = email;
    }
    
    // TODO implement better email validation
    
    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email cannot be empty");

        if (!email.Contains("@"))
            throw new DomainException("Email must contain @");

        return new Email(email);
    }
}