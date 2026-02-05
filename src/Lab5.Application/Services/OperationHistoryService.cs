using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.OperationHistories;
using Lab5.Application.Contracts.OperationHistories.Models;
using Lab5.Application.Contracts.OperationHistories.Operations;
using Lab5.Application.Mapping;
using Lab5.Domain.Accounts;
using Lab5.Domain.OperationHistories;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Services;

public class OperationHistoryService : IOperationHistoryService
{
    private readonly IPersistenceContext _context;

    public OperationHistoryService(IPersistenceContext context)
    {
        _context = context;
    }

    public GetOperationHistoryDetails.Response GetOperationHistoryDetails(GetOperationHistoryDetails.Request request)
    {
        var userSessionKey = new UserSessionKey(request.SessionKey);

        UserSession? session = _context.UserSessions
            .Query(UserSessionQuery.Build(builder => builder.WithSessionKey(userSessionKey)))
            .SingleOrDefault();

        if (session is null)
        {
            return new GetOperationHistoryDetails.Response.Failure("Could not find session");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithAccountId(session.AccountId)))
            .SingleOrDefault();

        if (account is null)
        {
            return new GetOperationHistoryDetails.Response.Failure("Could not find account");
        }

        OperationHistory[] operations = _context.Operations
            .Query(OperationHistoryQuery.Build(builder => builder.WithAccountsId(account.Id)))
            .ToArray();

        IReadOnlyCollection<OperationHistoryDto> operationsDto = operations.Select(x => x.MapToDto()).ToList();

        return new GetOperationHistoryDetails.Response.Successfully(new OperationHistoryDetailsDto(operationsDto));
    }
}