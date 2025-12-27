using Lab5.Domain.OperationHIstories;
using SourceKit.Generators.Builder.Annotations;

namespace Lab5.Applicaiton.Abstractions.Queries;

[GenerateBuilder]
public sealed partial record OperationHistoryQuery(OperationHistoryId[] HistoryIds);