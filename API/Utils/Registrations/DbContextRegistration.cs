using Data;
using Microsoft.EntityFrameworkCore;

namespace API.Utils.Registrations;

internal static class DbContextRegistration
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MarketplaceContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}