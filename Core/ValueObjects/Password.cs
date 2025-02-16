using Core.Utils;

namespace Core.ValueObjects;

public record Password
{
    public string Hash { get; }

    public Password(string value)
    {
        // TODO REGEX VALIDATION
        // TODO HASH PASSWORD
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("Password cannot be empty");
        }

        if (value.Length < 6 || value.Length > 20)
        {
            throw new DomainException("Password must be between 6 and 20 characters");
        }

        // TODO GENERATE Hash
        Hash = value;
    }

    public static implicit operator string(Password password) => password.Hash;
    public static implicit operator Password(string password) => new(password);
}