using Pure.RelationalSchema.Abstractions.ColumnType;

namespace Pure.RelationalSchema.Tests.EqualityComparers;

public sealed record ColumnTypeEqualityComparer : IEqualityComparer<IColumnType>
{
    public bool Equals(IColumnType? column, IColumnType? column1)
    {
        return column!.Name.TextValue == column1!.Name.TextValue;
    }

    public int GetHashCode(IColumnType obj)
    {
        throw new NotSupportedException();
    }
}
