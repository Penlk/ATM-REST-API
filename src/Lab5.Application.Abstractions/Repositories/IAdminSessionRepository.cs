using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminSessionRepository
{
    AdminSession Add(AdminSession session);

    IEnumerable<UserSession> Query(AdminSessionQuery query);
}