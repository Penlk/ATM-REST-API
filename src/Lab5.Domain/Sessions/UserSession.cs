using Lab5.Domain.Accounts;

namespace Lab5.Domain.Sessions;

public class UserSession
{
    public UserSession(UserSessionKey key, AccountId accountId)
    {
        Key = key;
        AccountId = accountId;
    }

    public UserSessionKey Key { get; }

    public AccountId AccountId { get; }
}