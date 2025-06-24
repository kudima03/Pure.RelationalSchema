using Pure.Primitives.Materialized.String;
using Pure.RelationalSchema.Abstractions.ColumnType;

namespace Pure.RelationalSchema.Tests.EqualityComparers;

public sealed record ColumnTypeEqualityComparer : IEqualityComparer<IColumnType>
{
    public bool Equals(IColumnType? column, IColumnType? column1)
    {
        return new MaterializedString(column!.Name).Value == new MaterializedString(column1!.Name).Value;
    }

    public int GetHashCode(IColumnType obj) { throw new NotSupportedException(); }
}