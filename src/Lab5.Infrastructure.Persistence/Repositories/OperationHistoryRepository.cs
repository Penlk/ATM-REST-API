using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Accounts;
using Lab5.Domain.OperationHistories;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly Dictionary<AccountId, List<OperationHistory>> _store =
        new Dictionary<AccountId, List<OperationHistory>>();

    private long _lastId = 0;

    public OperationHistory Add(OperationHistory operationHistory)
    {
        ++_lastId;
        var newOperationHistory = new OperationHistory(
            new OperationHistoryId(_lastId),
            operationHistory.AccountId,
            operationHistory.Operation);

        if (!_store.ContainsKey(operationHistory.AccountId))
        {
            _store.Add(operationHistory.AccountId, new List<OperationHistory>());
        }

        _store[operationHistory.AccountId].Add(newOperationHistory);

        return newOperationHistory;
    }

    public IEnumerable<OperationHistory> Query(OperationHistoryQuery query)
    {
        return query.AccountsIds.Where(x => _store.ContainsKey(x)).SelectMany(x => _store[x]);
    }
}