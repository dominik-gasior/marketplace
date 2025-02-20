namespace Core.Utils.Handling.Requests;

public interface IRequestHandler<in IRequest, TResponse>
{
    Task<TResponse> HandleAsync(IRequest query, CancellationToken token = default);
}