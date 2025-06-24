using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.Table;

public sealed record Table : ITable
{
    public Table(IString name, IEnumerable<IColumn> columns, IEnumerable<IIndex> indexes)
    {
        Name = name;
        Columns = columns;
        Indexes = indexes;
    }

    public IString Name { get; }

    public IEnumerable<IColumn> Columns { get; }

    public IEnumerable<IIndex> Indexes { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}