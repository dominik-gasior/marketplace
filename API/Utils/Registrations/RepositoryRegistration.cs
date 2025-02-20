using Core.Features.Transactions;
using Data.Repositories.Transactions;

namespace API.Utils.Registrations;

internal static class RepositoryRegistration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan .FromAssemblyOf<TransactionRepository>()
            .AddClasses(classes => classes.AssignableTo<ITransactionRepository>())
            .AsImplementedInterfaces()
            .WithTransientLifetime()); 
    }
}