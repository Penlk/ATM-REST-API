using Lab5.Application.Contracts.OperationHistories.Models;

namespace Lab5.Application.Contracts.OperationHistories.Operations;

public static class GetOperationHistoryDetails
{
    public readonly record struct Request(Guid SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Successfully(OperationHistoryDetailsDto Operations) : Response;

        public sealed record Failure(string Message) : Response;
    }
}