using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Repositories;

namespace Lab5.Infrastructure.Persistence;

public class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(
        IAccountRepository accounts,
        IUserSessionRepository userSessions,
        IAdminSessionRepository adminSessions,
        IOperationHistoryRepository operations)
    {
        Accounts = accounts;
        UserSessions = userSessions;
        AdminSessions = adminSessions;
        Operations = operations;
    }

    public IAccountRepository Accounts { get; }

    public IUserSessionRepository UserSessions { get; }

    public IAdminSessionRepository AdminSessions { get; }

    public IOperationHistoryRepository Operations { get; }
}