using Lab5.Domain.Accounts.Results;
using Lab5.Domain.OperationHistories;
using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Accounts;

public class Account
{
    public Account(AccountId id, Money money, PinCode pinCode)
    {
        Id = id;
        Money = money;
        PinCode = pinCode;
    }

    public AccountId Id { get; }

    public PinCode PinCode { get; }

    public Money Money { get; private set; }

    public WithDrawMoneyResult WithDraw(Money money)
    {
        if (Money < money)
        {
            return new WithDrawMoneyResult.Failure("Cannot be negative balance");
        }

        Money -= money;

        return new WithDrawMoneyResult.Successfully(new OperationHistory(
            OperationHistoryId.Default,
            Id,
            TypeOperation.WithDraw));
    }

    public OperationHistory Replenish(Money money)
    {
        Money += money;

        return new OperationHistory(OperationHistoryId.Default, Id, TypeOperation.Replenish);
    }
}