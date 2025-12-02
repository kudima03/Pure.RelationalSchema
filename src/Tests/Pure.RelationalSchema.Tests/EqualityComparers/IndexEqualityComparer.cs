using Pure.RelationalSchema.Abstractions.Index;

namespace Pure.RelationalSchema.Tests.EqualityComparers;

public sealed record IndexEqualityComparer : IEqualityComparer<IIndex>
{
    public bool Equals(IIndex? column, IIndex? column1)
    {
        return column!.IsUnique.BoolValue == column1!.IsUnique.BoolValue
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
