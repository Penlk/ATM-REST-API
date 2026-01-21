using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.OperationHistories;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly Dictionary<OperationHistoryId, OperationHistory> _store =
        new Dictionary<OperationHistoryId, OperationHistory>();

    private long _lastId = 0;

    public OperationHistory Add(OperationHistory operationHistory)
    {
        ++_lastId;
        var newOperationHistory = new OperationHistory(
            new OperationHistoryId(_lastId),
            operationHistory.UserSessionId,
            operationHistory.AccountId,
            operationHistory.Operation);

        _store.Add(newOperationHistory.Id, newOperationHistory);

        return newOperationHistory;
    }

    public IEnumerable<OperationHistory> Query(OperationHistoryQuery query)
    {
        return _store.Where(x => query.HistoryIds.Contains(x.Key)).Select(x => x.Value);
    }
}