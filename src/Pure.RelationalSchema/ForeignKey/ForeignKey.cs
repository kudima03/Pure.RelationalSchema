using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.ForeignKey;

public sealed record ForeignKey : IForeignKey
{
    public ForeignKey(
        ITable referencingTable,
        IEnumerable<IColumn> referencingColumns,
        ITable referencedTable,
        IEnumerable<IColumn> referencedColumns
    )
    {
        ReferencingTable = referencingTable;
        ReferencingColumns = referencingColumns;
        ReferencedTable = referencedTable;
        ReferencedColumns = referencedColumns;
    }

    public ITable ReferencingTable { get; }

    public IEnumerable<IColumn> ReferencingColumns { get; }

    public ITable ReferencedTable { get; }

    public IEnumerable<IColumn> ReferencedColumns { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
