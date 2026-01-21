namespace Lab5.Domain.Sessions;

public class AdminSession
{
    public AdminSession(AdminSessionKey key, SystemPassword password)
    {
        Key = key;
        Password = password;
    }

    public AdminSessionKey Key { get; }

    public SystemPassword Password { get; }
}