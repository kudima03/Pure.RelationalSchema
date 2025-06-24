using Pure.Primitives.Materialized.String;
using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.Tests.EqualityComparers;

public sealed record TableEqualityComparer : IEqualityComparer<ITable>
{
    public bool Equals(ITable? column, ITable? column1)
    {
        return new MaterializedString(column!.Name).Value == new MaterializedString(column1!.Name).Value &&
               column.Columns.SequenceEqual(column1.Columns, new ColumnEqualityComparer()) &&
               column.Indexes.SequenceEqual(column1.Indexes, new IndexEqualityComparer());
    }

    public int GetHashCode(ITable obj) { throw new NotSupportedException(); }
}