namespace Lab5.Domain.Sessions;

public record UserSessionKey(Guid Id)
{
    public static UserSessionKey NextKey => new UserSessionKey(Guid.NewGuid());
}