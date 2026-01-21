namespace Lab5.Application.Contracts.OperationHistories.Models;

public record OperationHistoryDto(
    long OperationId,
    Guid UserSessionKey,
    long AccountId,
    TypeOperationDto TypeOperationDto);