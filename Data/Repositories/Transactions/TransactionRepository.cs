using Core.Features.Transactions;
using Core.Models;

namespace Data.Repositories.Transactions;

public class TransactionRepository : ITransactionRepository
{
    private readonly MarketplaceContext _context;

    public TransactionRepository(MarketplaceContext context)
    {
        _context = context;
    }

    public Task<List<Transaction>> GetAvailableTransactionsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Transaction>> GetUserTransactionsAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> CreateTransactionAsync(Transaction transaction, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RemoveTransactionAsync(Guid transactionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}