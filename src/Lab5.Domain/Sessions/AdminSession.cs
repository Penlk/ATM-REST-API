using Lab5.Domain.Accounts;
using Lab5.Domain.ValueObjects;

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

    public Account AddAccount(AccountId accountId, PinCode pinCode)
    {
        return new Account(accountId, new Money(0), pinCode);
    }
}