using Lab5.Domain.Accounts;

namespace Lab5.Domain.OperationHistories;

public class OperationHistory
{
    public OperationHistoryId Id { get; }

    public AccountId AccountId { get; }

    public TypeOperation Operation { get; }

    public OperationHistory(OperationHistoryId id, AccountId accountId, TypeOperation operation)
    {
        Id = id;
        AccountId = accountId;
        Operation = operation;
    }
}