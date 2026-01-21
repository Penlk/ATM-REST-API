using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;

namespace Lab5.Domain.OperationHistories;

public class OperationHistory
{
    public OperationHistoryId Id { get; }

    public UserSessionKey UserSessionId { get; }

    public AccountId AccountId { get; }

    public TypeOperation Operation { get; }

    public OperationHistory(OperationHistoryId id, UserSessionKey userSessionId, AccountId accountId, TypeOperation operation)
    {
        Id = id;
        UserSessionId = userSessionId;
        AccountId = accountId;
        Operation = operation;
    }
}