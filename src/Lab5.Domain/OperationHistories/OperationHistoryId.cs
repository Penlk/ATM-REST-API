namespace Lab5.Domain.OperationHistories;

public readonly record struct OperationHistoryId(long Value)
{
    public static readonly OperationHistoryId Default = new(default);
}