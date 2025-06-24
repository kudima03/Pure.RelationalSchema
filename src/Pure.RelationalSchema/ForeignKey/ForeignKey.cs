using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.ForeignKey;

public sealed record ForeignKey : IForeignKey
{
    public ForeignKey(
        ITable referencingTable, 
        IColumn referencingColumn, 
        ITable referencedTable, 
        IColumn referencedColumn)
    {
        ReferencingTable = referencingTable;
        ReferencingColumn = referencingColumn;
        ReferencedTable = referencedTable;
        ReferencedColumn = referencedColumn;
    }

    public ITable ReferencingTable { get; }

    public IColumn ReferencingColumn { get; }

    public ITable ReferencedTable { get; }

    public IColumn ReferencedColumn { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}