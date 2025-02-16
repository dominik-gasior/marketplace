namespace Core.Utils.Handling.Events;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    Task Handle(TEvent @event);
}