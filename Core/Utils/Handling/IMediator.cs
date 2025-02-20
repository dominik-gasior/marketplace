using Core.Utils.Handling.Events;
using Core.Utils.Handling.Requests;

namespace Core.Utils.Handling;

public interface IMediator
{
    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken = default); 
    Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
}