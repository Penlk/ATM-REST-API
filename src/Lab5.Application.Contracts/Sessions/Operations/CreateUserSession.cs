using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Sessions.Operations;

public static class CreateUserSession
{
    public readonly record struct Request(long AccountId, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Successfully(UserSessionDto UserSessionDto) : Response;

        public sealed record Failure(string Message) : Response;
    }
}