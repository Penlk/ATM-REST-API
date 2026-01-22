using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class UserSessionRepository : IUserSessionRepository
{
    private readonly Dictionary<UserSessionKey, UserSession> _store = new Dictionary<UserSessionKey, UserSession>();

    public void Add(UserSession session)
    {
        _store.Add(session.Key, session);
    }

    public IEnumerable<UserSession> Query(UserSessionQuery query)
    {
        return query.SessionKeys.Where(x => _store.ContainsKey(x)).Select(x => _store[x]);
    }
}