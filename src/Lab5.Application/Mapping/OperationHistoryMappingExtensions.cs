using Lab5.Application.Contracts.OperationHistories.Models;
using Lab5.Domain.OperationHistories;
using System.Diagnostics;

namespace Lab5.Application.Mapping;

public static class OperationHistoryMappingExtensions
{
    public static string MapToDto(this TypeOperation typeOperation)
    {
        return typeOperation switch
        {
            TypeOperation.Replenish => "Replenish",
            TypeOperation.WithDraw => "With draw",
            _ => throw new UnreachableException(),
        };
    }

    public static OperationHistoryDto MapToDto(this OperationHistory operationHistory)
    {
        return new OperationHistoryDto(
            operationHistory.Id.Value,
            operationHistory.AccountId.Value,
            operationHistory.Operation.MapToDto());
    }
}