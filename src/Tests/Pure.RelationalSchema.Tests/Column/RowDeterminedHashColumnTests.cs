using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Column;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.Tests.EqualityComparers;

namespace Pure.RelationalSchema.Tests.Column;

public sealed record RowDeterminedHashColumnTests
{
    [Fact]
    public void InitializeType()
    {
        IColumnType expectedType = new DeterminedHashColumnType();
        IColumn column = new RowDeterminedHashColumn();
        Assert.Equal(expectedType, column.Type, new ColumnTypeEqualityComparer());
    }

    [Fact]
    public void InitializeName()
    {
        IColumn column = new RowDeterminedHashColumn();
        Assert.Equal("determined_hash_column", column.Name.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RowDeterminedHashColumn().GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RowDeterminedHashColumn().ToString()
        );
    }
}
