using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class MarketplaceContext : DbContext
{
    public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<PriceProduct> PriceProducts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
}