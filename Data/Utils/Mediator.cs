using Core.Utils.Handling;
using Core.Utils.Handling.Events;
using Core.Utils.Handling.Requests;

namespace Data.Utils;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;
    
    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> query)
    {
        var handler = (IRequestHandler<IRequest<TResponse>, TResponse>)_serviceProvider.GetService(typeof(IRequestHandler<IRequest<TResponse>, TResponse>));
        if (handler != null)
        {
            return await handler.Handle(query);
        }
        
        throw new Exception("Handler not found");
    }

    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
    {
        var handlers = (IEnumerable<IEventHandler<TEvent>>)_serviceProvider.GetService(typeof(IEnumerable<IEventHandler<TEvent>>));
        if (handlers != null)
        {
            foreach (var handler in handlers)
            {
                await handler.Handle(@event);
            }
        }
    }
}