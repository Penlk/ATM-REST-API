using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.Accounts.Results;
using Lab5.Domain.OperationHistories;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;

namespace Lab5.Application.Services;

public class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        var adminSessionKey = new AdminSessionKey(request.AdminKey);
        AdminSessionQuery adminSessionQuery = new AdminSessionQuery.Builder().WithSessionKey(adminSessionKey).Build();

        IEnumerable<AdminSession> admins = _context.AdminSessions.Query(adminSessionQuery).ToList();

        if (admins.Any() is false)
        {
            return new CreateAccount.Response.Failure("No admin session found");
        }

        Account account =
            _context.Accounts.Add(new Account(AccountId.Default, new Money(0), new PinCode(request.PinCode)));

        return new CreateAccount.Response.Successfully(account.MapToDto());
    }

    public GetAccountBalance.Response GetAccountBalance(GetAccountBalance.Request request)
    {
        UserSession? session = FindUserSession(request.SessionKey);

        if (session is null)
        {
            return new GetAccountBalance.Response.Failure("No user's session found");
        }

        Account? account = FindAccount(session.AccountId);

        if (account is null)
        {
            return new GetAccountBalance.Response.Failure("No account found");
        }

        return new GetAccountBalance.Response.Successfully(account.Money.Value);
    }

    public ReplenishAccountBalance.Response ReplenishAccountBalance(ReplenishAccountBalance.Request request)
    {
        UserSession? session = FindUserSession(request.SessionKey);

        if (session is null)
        {
            return new ReplenishAccountBalance.Response.Failure("No user's session found");
        }

        Account? account = FindAccount(session.AccountId);

        if (account is null)
        {
            return new ReplenishAccountBalance.Response.Failure("No account found");
        }

        OperationHistory operation = account.Replenish(new Money(request.Money));

        _context.Operations.Add(operation);

        return new ReplenishAccountBalance.Response.Successfully(account.Money.Value);
    }

    public WithDrawAccountBalance.Response WithDrawAccountBalance(WithDrawAccountBalance.Request request)
    {
        UserSession? session = FindUserSession(request.SessionKey);

        if (session is null)
        {
            return new WithDrawAccountBalance.Response.Failure("No user's session found");
        }

        Account? account = FindAccount(session.AccountId);

        if (account is null)
        {
            return new WithDrawAccountBalance.Response.Failure("No account found");
        }

        WithDrawMoneyResult operationResult = account.WithDraw(new Money(request.Money));

        if (operationResult is WithDrawMoneyResult.Failure fail)
        {
            return new WithDrawAccountBalance.Response.Failure(fail.Message);
        }

        if (operationResult is WithDrawMoneyResult.Successfully successfully)
        {
            _context.Operations.Add(successfully.OperationHistory);

            return new WithDrawAccountBalance.Response.Successfully(account.Money.Value);
        }

        return new WithDrawAccountBalance.Response.Failure("Failed to withdraw");
    }

    private UserSession? FindUserSession(Guid userSessionId)
    {
        var userSessionKey = new UserSessionKey(userSessionId);
        UserSessionQuery query = new UserSessionQuery.Builder().WithSessionKey(userSessionKey).Build();

        IEnumerable<UserSession> sessions = _context.UserSessions.Query(query);

        return sessions.SingleOrDefault();
    }

    private Account? FindAccount(AccountId accountId)
    {
        AccountQuery query = new AccountQuery.Builder().WithAccountId(accountId).Build();

        IEnumerable<Account> accounts = _context.Accounts.Query(query);
        return accounts.SingleOrDefault();
    }
}