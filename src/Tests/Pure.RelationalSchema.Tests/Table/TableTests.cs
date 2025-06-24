using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Bool;
using Pure.Primitives.Materialized.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.Primitives.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.Tests.EqualityComparers;

namespace Pure.RelationalSchema.Tests.Table;

using Column = RelationalSchema.Column.Column;
using Index = RelationalSchema.Index.Index;
using Table = RelationalSchema.Table.Table;

public sealed record TableTests
{
    [Fact]
    public void InitializeName()
    {
        IString expectedName = new RandomString(new UShort(10));
        ITable table = new Table(expectedName, [], []);
        Assert.Equal(new MaterializedString(expectedName).Value, new MaterializedString(table.Name).Value);
    }

    [Fact]
    public void InitializeColumns()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new Column(new RandomString(new UShort(10)), new DateColumnType()),
            new Column(new RandomString(new UShort(10)), new StringColumnType()),
            new Column(new RandomString(new UShort(10)), new IntColumnType()),
            new Column(new RandomString(new UShort(10)), new LongColumnType()),
        ];

        ITable table = new Table(new EmptyString(), columns, []);
        Assert.Equal(table.Columns, columns, new ColumnEqualityComparer());
    }

    [Fact]
    public void InitializeIndexes()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new Column(new RandomString(new UShort(10)), new DateColumnType()),
            new Column(new RandomString(new UShort(10)), new StringColumnType()),
            new Column(new RandomString(new UShort(10)), new IntColumnType()),
            new Column(new RandomString(new UShort(10)), new LongColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new Index(new True(), columns.Take(2)),
            new Index(new False(), columns.Skip(2)),
        ];

        ITable table = new Table(new EmptyString(), columns, indexes);
        Assert.Equal(table.Indexes, indexes, new IndexEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Table(new RandomString(new UShort(10)), [], []).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Table(new RandomString(new UShort(10)), [], []).ToString());
    }
}