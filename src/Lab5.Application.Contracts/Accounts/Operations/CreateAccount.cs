using Lab5.Application.Contracts.Accounts.Models;

namespace Lab5.Application.Contracts.Accounts.Operations;

public static class CreateAccount
{
    public readonly record struct Request(Guid AdminKey, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Successfully(AccountDto AccountDto) : Response;

        public sealed record Failure(string Message) : Response;
    }
}