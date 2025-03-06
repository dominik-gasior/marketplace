using Core.ValueObjects;

namespace Core.Models;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }
    public Address Address { get; private set; }
    public Password Password { get; private set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsActive { get; private set; } = true;
    public bool IsDeleted { get; private set; } = false;
    public bool IsSeller { get; init; } = false;
    public List<Transaction> Transactions { get; init; } = [];
    
    public static User Create(
        Name firstName,
        Name lastName,
        Email email,
        Phone phone,
        Password password,
        Address address)
    {
        // TODO: Add validation
        return new User(firstName, lastName, email, phone, password, address);
    }
    
    private User(
        Name firstName,
        Name lastName,
        Email email,
        Phone phone,
        Password password,
        Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Password = password;
        Address = address;
    }

    private User()
    {

    }
}