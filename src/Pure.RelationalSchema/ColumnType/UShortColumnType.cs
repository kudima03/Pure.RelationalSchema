using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ColumnType;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.ColumnType;

public sealed record UShortColumnType : IColumnType
{
    IString IColumnType.Name { get; } = new String("ulong");

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}