using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ColumnType;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.ColumnType;

public sealed record LongColumnType : IColumnType
{
    IString IColumnType.Name { get; } = new String("long");

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
