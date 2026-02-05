namespace Lab5.Application.Contracts.OperationHistories.Models;

public record OperationHistoryDto(
    long OperationId,
    long AccountId,
    string TypeOperation);