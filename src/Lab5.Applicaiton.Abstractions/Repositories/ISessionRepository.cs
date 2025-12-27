using Lab5.Applicaiton.Abstractions.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Applicaiton.Abstractions.Repositories;

public interface ISessionRepository
{
    Session Add(Session session);

    IEnumerable<Session> Query(SessionQuery query);
}