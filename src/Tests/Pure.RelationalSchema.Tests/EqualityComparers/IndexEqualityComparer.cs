using Pure.RelationalSchema.Abstractions.Index;

namespace Pure.RelationalSchema.Tests.EqualityComparers;

public sealed record IndexEqualityComparer : IEqualityComparer<IIndex>
{
    public bool Equals(IIndex? column, IIndex? column1)
    {
        return new MaterializedBool(column!.IsUnique).Value
                == new MaterializedBool(column1!.IsUnique).Value
            && column.Columns.SequenceEqual(
                column1.Columns,
                new ColumnEqualityComparer()
            );
    }

    public int GetHashCode(IIndex obj)
    {
        throw new NotSupportedException();
    }
}
