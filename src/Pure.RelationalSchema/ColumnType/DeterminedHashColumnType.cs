using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ColumnType;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.ColumnType;

public sealed record DeterminedHashColumnType : IColumnType
{
    public IString Name { get; } = new String("determined_hash");

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
