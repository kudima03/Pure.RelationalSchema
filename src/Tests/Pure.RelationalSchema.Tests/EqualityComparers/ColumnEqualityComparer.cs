using Pure.RelationalSchema.Abstractions.Column;

namespace Pure.RelationalSchema.Tests.EqualityComparers;

public sealed record ColumnEqualityComparer : IEqualityComparer<IColumn>
{
    public bool Equals(IColumn? column, IColumn? column1)
    {
        return column!.Name.TextValue == column1!.Name.TextValue
            && column.Type.Name.TextValue == column1.Type.Name.TextValue;
    }

    public int GetHashCode(IColumn obj)
    {
        throw new NotSupportedException();
    }
}
