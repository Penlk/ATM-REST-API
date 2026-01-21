using Lab5.Application.Contracts.Sessions.Operations;

namespace Lab5.Application.Contracts.Sessions;

public interface ISessionService
{
    CreateUserSession.Response CreateUserSession(CreateUserSession.Request request);
}