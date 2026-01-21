using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserSessionRepository
{
    UserSession Add(UserSession session);

    IEnumerable<UserSession> Query(UserSessionQuery query);
}