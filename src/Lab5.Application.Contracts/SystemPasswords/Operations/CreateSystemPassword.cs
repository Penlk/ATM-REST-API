namespace Lab5.Application.Contracts.SystemPasswords.Operations;

public static class CreateSystemPassword
{
    public readonly record struct Request(Guid AdminSession, string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Successfully() : Response;

        public sealed record Failure(string Message) : Response;
    }
}