using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class AdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<AdminSessionKey, AdminSession> _store = new Dictionary<AdminSessionKey, AdminSession>();

    public void Add(AdminSession session)
    {
        _store.Add(session.Key, session);
    }

    public IEnumerable<AdminSession> Query(AdminSessionQuery query)
    {
        return _store.Where(x => query.SessionKeys.Contains(x.Key)).Select(x => x.Value);
    }
}