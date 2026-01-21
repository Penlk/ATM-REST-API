using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.OperationHistories;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOperationHistoryRepository
{
    OperationHistory Add(OperationHistory operationHistory);

    IEnumerable<OperationHistoryQuery> Query(OperationHistoryQuery query);
}