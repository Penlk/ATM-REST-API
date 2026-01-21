using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Mapping;

public static class SessionMappingExtensions
{
    public static AdminSessionDto MapToDto(this AdminSession session)
    {
        return new AdminSessionDto(session.Key.Id, session.Password.Password);
    }

    public static UserSessionDto MapToDto(this UserSession session)
    {
        return new UserSessionDto(session.Key.Id, session.AccountId.Value);
    }
}