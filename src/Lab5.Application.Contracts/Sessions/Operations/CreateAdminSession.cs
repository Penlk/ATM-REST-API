using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Contracts.Sessions.Operations;

public class CreateAdminSession
{
    public readonly record struct Request(string Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Successfully(AdminSessionDto AdminSessionDto) : Response;

        public sealed record Failure(string Message) : Response;
    }
}