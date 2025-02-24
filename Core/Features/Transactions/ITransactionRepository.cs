using Core.Models;

namespace Core.Features.Transactions;

public interface ITransactionRepository
{
    Task<Guid> CreateTransactionAsync(Transaction transaction, CancellationToken cancellationToken);
    Task RemoveTransactionAsync(Guid transactionId, CancellationToken cancellationToken);
}