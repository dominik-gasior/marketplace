using Core.Utils.Handling;
using Core.Utils.Handling.Requests;
using Data.Features.Products.GetProduct;
using Data.Features.Products.GetProduct.DTOs;
using Data.Utils;
using Data.Utils.Results;

namespace API.Utils.Registrations;

internal static class MediatorRegistration
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(GetProductHandler), typeof(IRequestHandler<,>))
            .AddClasses(classes =>
                classes.AssignableTo(typeof(IRequestHandler<,>))
                    .Where(c => !c.IsAbstract && !c.IsGenericTypeDefinition))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        
        services.AddScoped<IMediator, Mediator>();
    }
}