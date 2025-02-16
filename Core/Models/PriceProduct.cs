using Core.ValueObjects;

namespace Core.Models;

public class PriceProduct
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid ProductId { get; init; }
    public Category Category { get; init; }
    public DateTime CreatedTime { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedTime { get; private set; } = DateTime.UtcNow;
    public PositiveNumber MedianPrice { get; private set; } = 0;
    public PositiveNumber LowestPrice { get; private set; } = 0;
    public PositiveNumber HighestPrice { get; private set; } = 0;
    public Percentage ChangePrice { get; private set; } = 0;
    
    public static PriceProduct Create(Guid productId, Category category)
    {
        return new PriceProduct(productId, category);
    }
    
    public void UpdatePrice(
        PositiveNumber medianPrice,
        PositiveNumber lowestPrice,
        PositiveNumber highestPrice,
        Percentage changePrice)
    {
        MedianPrice = medianPrice;
        LowestPrice = lowestPrice;
        HighestPrice = highestPrice;
        ChangePrice = changePrice;
        UpdatedTime = DateTime.UtcNow;
    }
    
    private PriceProduct(
        Guid productId,
        Category category)
    {
        ProductId = productId;
        Category = category;
    }
}