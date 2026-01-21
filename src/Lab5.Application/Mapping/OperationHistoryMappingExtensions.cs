using Lab5.Application.Contracts.OperationHistories.Models;
using Lab5.Domain.OperationHistories;
using System.Diagnostics;

namespace Lab5.Application.Mapping;

public static class OperationHistoryMappingExtensions
{
    public static TypeOperationDto MapToDto(this TypeOperation typeOperation)
    {
        return typeOperation switch
        {
            TypeOperation.Replenish => TypeOperationDto.Replenish,
            TypeOperation.WithDraw => TypeOperationDto.WithDraw,
            _ => throw new UnreachableException(),
        };
    }

    public static OperationHistoryDto MapToDto(this OperationHistory operationHistory)
    {
        return new OperationHistoryDto(
            operationHistory.Id.Value,
            operationHistory.UserSessionId.Id,
            operationHistory.AccountId.Value,
            operationHistory.Operation.MapToDto());
    }
}