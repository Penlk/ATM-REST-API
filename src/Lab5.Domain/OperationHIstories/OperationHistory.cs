using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;

namespace Lab5.Domain.OperationHIstories;

public class OperationHistory
{
    public OperationHistoryId Id { get; }

    public SessionId SessionId { get; }

    public AccountId AccountId { get; }

    public OperationHistory(OperationHistoryId id, SessionId sessionId, AccountId accountId)
    {
        Id = id;
        SessionId = sessionId;
        AccountId = accountId;
    }
}