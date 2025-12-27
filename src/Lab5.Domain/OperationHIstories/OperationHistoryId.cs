namespace Lab5.Domain.OperationHIstories;

public readonly record struct OperationHistoryId(long Value)
{
    public static readonly OperationHistoryId Default = new(default);
}