using Core.ValueObjects;

namespace Core.Models;

public class Transaction
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid ProductID { get; init; }
    public Guid? SellerID { get; private set; } = null;
    public Guid? BuyerID { get; private set; } = null;
    public PositiveNumber Price { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public Status Status { get; private set; } = Status.Pending;

    public static Transaction CreateByBuyer(Guid buyerId, Guid productId, PositiveNumber price)
    {
        var newTransaction = new Transaction(productId, price)
        {
            BuyerID = buyerId
        };

        return newTransaction;
    }
    
    public static Transaction CreateBySeller(Guid sellerId, Guid productId, PositiveNumber price)
    {
        var newTransaction = new Transaction(productId, price)
        {
            SellerID = sellerId
        };

        return newTransaction;
    }
    
    public void Complete()
    {
        Status = Status.Completed;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Cancel()
    {
        Status = Status.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }
    
    private Transaction(Guid productId, PositiveNumber price)
    {
        ProductID = productId;
        Price = price;
    }
}