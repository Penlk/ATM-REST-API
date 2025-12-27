using Lab5.Domain.Accounts.Results;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public class Account
{
    public AccountId Id { get; }

    public Money Money { get; private set; }

    public SessionId SessionId { get; }

    public Account(AccountId id, Money money, SessionId sessionId)
    {
        Id = id;
        Money = money;
        SessionId = sessionId;
    }

    public RemovalMoneyResult RemoveMoney(Money money)
    {
        if (Money < money)
        {
            return new RemovalMoneyResult.Failure("Cannot be negative balance");
        }

        Money -= money;

        return new RemovalMoneyResult.Successfully();
    }

    public void Replenish(Money money)
    {
        Money += money;
    }
}