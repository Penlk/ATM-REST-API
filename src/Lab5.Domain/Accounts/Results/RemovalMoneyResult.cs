namespace Lab5.Domain.Accounts.Results;

public abstract record RemovalMoneyResult
{
    private RemovalMoneyResult() { }

    public sealed record Successfully : RemovalMoneyResult;

    public sealed record Failure(string Messgae) : RemovalMoneyResult;
}