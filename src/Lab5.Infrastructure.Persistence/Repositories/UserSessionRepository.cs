using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class UserSessionRepository
{
    private readonly Dictionary<UserSessionKey, UserSession> _store = new Dictionary<UserSessionKey, UserSession>();

    public void Add(UserSession session)
    {
        _store.Add(session.Key, session);
    }

    public IEnumerable<UserSession> Query(UserSessionQuery query)
    {
        return _store.Where(x => query.SessionKeys.Contains(x.Key)).Select(x => x.Value);
    }
}