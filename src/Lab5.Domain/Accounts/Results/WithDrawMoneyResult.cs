using Lab5.Domain.OperationHistories;

namespace Lab5.Domain.Accounts.Results;

public abstract record WithDrawMoneyResult
{
    private WithDrawMoneyResult() { }

    public sealed record Successfully(OperationHistory OperationHistory) : WithDrawMoneyResult;

    public sealed record Failure(string Message) : WithDrawMoneyResult;
}