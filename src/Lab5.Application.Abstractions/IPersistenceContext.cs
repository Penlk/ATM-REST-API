using Lab5.Application.Abstractions.Repositories;

namespace Lab5.Application.Abstractions;

public interface IPersistenceContext
{
    IAccountRepository Accounts { get; }

    IUserSessionRepository UserSessions { get; }

    IAdminSessionRepository AdminSessions { get; }

    IOperationHistoryRepository Operations { get; }

    ISystemPasswordRepository SystemPasswords { get; }
}