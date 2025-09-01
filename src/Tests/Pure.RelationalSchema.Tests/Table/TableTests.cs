using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Materialized.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Random;
using Pure.RelationalSchema.Tests.EqualityComparers;
using _Table = Pure.RelationalSchema.Table.Table;

namespace Pure.RelationalSchema.Tests.Table;

public sealed record TableTests
{
    [Fact]
    public void InitializeName()
    {
        IString expectedName = new RandomString(new UShort(10));
        ITable table = new _Table(expectedName, [], []);
        Assert.Equal(
            new MaterializedString(expectedName).Value,
            new MaterializedString(table.Name).Value
        );
    }

    [Fact]
    public void InitializeColumns()
    {
        IEnumerable<IColumn> columns = new RandomColumnsCollection();

        ITable table = new _Table(
            new RandomString(),
            columns,
            new RandomIndexesCollection()
        );
        Assert.Equal(table.Columns, columns, new ColumnEqualityComparer());
    }

    [Fact]
    public void InitializeIndexes()
    {
        IEnumerable<IIndex> indexes = new RandomIndexesCollection();

        ITable table = new _Table(
            new RandomString(),
            new RandomColumnsCollection(),
            indexes
        );

        Assert.Equal(table.Indexes, indexes, new IndexEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Table(
                new RandomString(),
                new RandomColumnsCollection(),
                new RandomIndexesCollection()
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Table(
                new RandomString(),
                new RandomColumnsCollection(),
                new RandomIndexesCollection()
            ).ToString()
        );
    }
}
