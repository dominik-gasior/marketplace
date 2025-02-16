namespace Core.Utils.Handling.Requests;

public interface IRequestHandler<in IRequest, TResponse>
{
    Task<TResponse> Handle(IRequest query, CancellationToken token = default);
}