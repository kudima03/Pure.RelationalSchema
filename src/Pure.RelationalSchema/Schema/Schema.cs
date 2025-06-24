using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;

namespace Pure.RelationalSchema.Schema;

public sealed record Schema : ISchema
{
    public Schema(
        IString name, 
        IEnumerable<ITable> tables, 
        IEnumerable<IForeignKey> foreignKeys)
    {
        Name = name;
        Tables = tables;
        ForeignKeys = foreignKeys;
    }

    public IString Name { get; }

    public IEnumerable<ITable> Tables { get; }

    public IEnumerable<IForeignKey> ForeignKeys { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}