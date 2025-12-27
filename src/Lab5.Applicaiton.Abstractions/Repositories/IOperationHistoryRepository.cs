using Lab5.Applicaiton.Abstractions.Queries;
using Lab5.Domain.OperationHIstories;

namespace Lab5.Applicaiton.Abstractions.Repositories;

public interface IOperationHistoryRepository
{
    OperationHistory Add(OperationHistory operationHistory);

    IEnumerable<OperationHistoryQuery> Query(OperationHistoryQuery query);
}