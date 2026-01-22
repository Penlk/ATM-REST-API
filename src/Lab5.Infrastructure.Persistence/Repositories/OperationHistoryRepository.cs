using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.OperationHistories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly Dictionary<UserSessionKey, OperationHistory> _store =
        new Dictionary<UserSessionKey, OperationHistory>();

    private long _lastId = 0;

    public OperationHistory Add(OperationHistory operationHistory)
    {
        ++_lastId;
        var newOperationHistory = new OperationHistory(
            new OperationHistoryId(_lastId),
            operationHistory.UserSessionId,
            operationHistory.AccountId,
            operationHistory.Operation);

        _store.Add(operationHistory.UserSessionId, newOperationHistory);

        return newOperationHistory;
    }

    public IEnumerable<OperationHistory> Query(OperationHistoryQuery query)
    {
        return query.UserSessionKeys.Where(x => _store.ContainsKey(x)).Select(x => _store[x]);
    }
}