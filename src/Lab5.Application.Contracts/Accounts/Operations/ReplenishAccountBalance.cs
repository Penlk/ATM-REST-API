namespace Lab5.Application.Contracts.Accounts.Operations;

public static class ReplenishAccountBalance
{
    public readonly record struct Request(Guid SessionKey, int Money);

    public abstract record Response
    {
        private Response() { }

        public sealed record Successfully(long Balance) : Response;

        public sealed record Failure(string Message) : Response;
    }
}