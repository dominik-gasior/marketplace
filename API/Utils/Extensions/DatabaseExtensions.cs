using Data;
using Microsoft.EntityFrameworkCore;

namespace API.Utils.Extensions;

public static class DatabaseExtensions
{
    public static void InitializeDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;


        var context = services.GetRequiredService<MarketplaceContext>();
        context.Database.MigrateAsync().GetAwaiter().GetResult();
    }
}