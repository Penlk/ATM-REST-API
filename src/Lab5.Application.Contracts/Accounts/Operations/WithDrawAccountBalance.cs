namespace Lab5.Application.Contracts.Accounts.Operations;

public class WithDrawAccountBalance
{
    public readonly record struct Request(Guid SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Successfully(long Balance) : Response;

        public sealed record Failure(string Message) : Response;
    }
}