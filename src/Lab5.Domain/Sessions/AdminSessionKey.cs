namespace Lab5.Domain.Sessions;

public record AdminSessionKey(Guid Id)
{
    public static AdminSessionKey NextKey => new AdminSessionKey(Guid.NewGuid());
}