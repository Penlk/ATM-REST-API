using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;

    public SessionService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        var accountId = new AccountId(request.AccountId);
        var pinCode = new PinCode(request.PinCode);

        Account? account = FindAccount(accountId);

        if (account is null)
        {
            return new CreateUserSession.Response.Failure("Could not find account");
        }

        if (account.PinCode != pinCode)
        {
            return new CreateUserSession.Response.Failure("Pin code does not match");
        }

        var userSession = new UserSession(UserSessionKey.NextKey, account.Id);

        _context.UserSessions.Add(userSession);

        return new CreateUserSession.Response.Successfully(userSession.MapToDto());
    }

    private Account? FindAccount(AccountId accountId)
    {
        AccountQuery query = new AccountQuery.Builder().WithAccountId(accountId).Build();

        IEnumerable<Account> accounts = _context.Accounts.Query(query);
        return accounts.SingleOrDefault();
    }
}