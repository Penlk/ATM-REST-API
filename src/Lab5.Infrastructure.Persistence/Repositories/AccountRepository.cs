using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Accounts;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountId, Account> _store = new Dictionary<AccountId, Account>();
    private long _lastId = 0;

    public Account Add(Account account)
    {
        ++_lastId;
        var newAccount = new Account(new AccountId(_lastId), account.Money, account.PinCode);

        _store.Add(newAccount.Id, newAccount);

        return newAccount;
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return query.AccountIds.Where(x => _store.ContainsKey(x)).Select(x => _store[x]);
    }
}