using Pure.RelationalSchema.Abstractions.Column;

namespace Pure.RelationalSchema.Tests.EqualityComparers;

public sealed record ColumnEqualityComparer : IEqualityComparer<IColumn>
{
    public bool Equals(IColumn? column, IColumn? column1)
    {
        return new MaterializedString(column!.Name).Value
                == new MaterializedString(column1!.Name).Value
            && new MaterializedString(column.Type.Name).Value
                == new MaterializedString(column1.Type.Name).Value;
    }

    public int GetHashCode(IColumn obj)
    {
        throw new NotSupportedException();
    }
}
