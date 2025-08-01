using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;

namespace Pure.RelationalSchema.Column;

public sealed record Column : IColumn
{
    public Column(IString name, IColumnType type)
    {
        Name = name;
        Type = type;
    }

    public IString Name { get; }

    public IColumnType Type { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
