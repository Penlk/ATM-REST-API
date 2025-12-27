using Lab5.Applicaiton.Abstractions.Repositories;

namespace Lab5.Applicaiton.Abstractions;

public interface IPersistenceContext
{
    IAccountRepository Accounts { get; }

    ISessionRepository Sessions { get; }

    IOperationHistoryRepository Operations { get; }
}