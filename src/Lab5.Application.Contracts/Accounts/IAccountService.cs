using Lab5.Application.Contracts.Accounts.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    CreateAccount.Response CreateAccount(CreateAccount.Request request);

    GetAccountBalance.Response GetAccountBalance(GetAccountBalance.Request request);

    ReplenishAccountBalance.Response ReplenishAccountBalance(ReplenishAccountBalance.Request request);

    WithDrawAccountBalance.Response WithDrawAccountBalance(WithDrawAccountBalance.Request request);
}