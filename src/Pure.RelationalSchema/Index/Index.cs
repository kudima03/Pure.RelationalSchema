using Pure.Primitives.Abstractions.Bool;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;

namespace Pure.RelationalSchema.Index;

public sealed record Index : IIndex
{
    public Index(IBool isUnique, IEnumerable<IColumn> columns)
    {
        IsUnique = isUnique;
        Columns = columns;
    }

    public IBool IsUnique { get; }

    public IEnumerable<IColumn> Columns { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
