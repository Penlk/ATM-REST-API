using Lab5.Applicaiton.Abstractions.Queries;
using Lab5.Domain.Accounts;

namespace Lab5.Applicaiton.Abstractions.Repositories;

public interface IAccountRepository
{
    Account Add(Account account);

    IEnumerable<Account> Query(AccountQuery query);
}