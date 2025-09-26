using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.Tests.EqualityComparers;

public sealed record ForeignKeyEqualityComparer : IEqualityComparer<IForeignKey>
{
    public bool Equals(IForeignKey? key, IForeignKey? key1)
    {
        IEqualityComparer<ITable> tableComparer = new TableEqualityComparer();
        IEqualityComparer<IColumn> columnComparer = new ColumnEqualityComparer();
        return tableComparer.Equals(key!.ReferencingTable, key1!.ReferencingTable)
            && tableComparer.Equals(key.ReferencedTable, key1.ReferencedTable)
            && key.ReferencedColumns.SequenceEqual(key1.ReferencedColumns, columnComparer)
            && key.ReferencingColumns.SequenceEqual(
                key1.ReferencingColumns,
                columnComparer
            );
    }

    public int GetHashCode(IForeignKey obj)
    {
        throw new NotSupportedException();
    }
}
