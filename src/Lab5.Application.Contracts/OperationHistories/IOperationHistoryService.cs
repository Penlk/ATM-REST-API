using Lab5.Application.Contracts.OperationHistories.Operations;

namespace Lab5.Application.Contracts.OperationHistories;

public interface IOperationHistoryService
{
    GetOperationHistoryDetails.Response GetOperationHistoryDetails(GetOperationHistoryDetails.Request request);
}