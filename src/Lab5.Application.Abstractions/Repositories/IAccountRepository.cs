using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account Add(Account account);

    IEnumerable<Account> Query(AccountQuery query);
}