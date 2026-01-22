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
        return query.SessionKeys.Where(x => _store.ContainsKey(x)).Select(x => _store[x]);
    }
}