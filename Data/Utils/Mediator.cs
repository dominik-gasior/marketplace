using Core.Utils.Handling;
using Core.Utils.Handling.Events;
using Core.Utils.Handling.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Utils;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;
    
    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken = default)
    {
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);
        
        return await (Task<TResponse>)handlerType
            .GetMethod(nameof(IRequestHandler<IRequest<TResponse>, TResponse>.HandleAsync))?
            .Invoke(handler, new object[] {query, cancellationToken})!;
    }

    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
    {
        var handlers = _serviceProvider.GetRequiredService<IEnumerable<IEventHandler<TEvent>>>();
        if (handlers != null)
        {
            foreach (var handler in handlers)
            {
                await handler.Handle(@event);
            }
        }
    }
}