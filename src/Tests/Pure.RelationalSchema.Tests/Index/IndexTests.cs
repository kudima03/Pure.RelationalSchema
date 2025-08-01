using Pure.Primitives.Bool;
using Pure.Primitives.Materialized.Bool;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.Tests.EqualityComparers;
using _Column = Pure.RelationalSchema.Column.Column;
using _Index = Pure.RelationalSchema.Index.Index;

namespace Pure.RelationalSchema.Tests.Index;

public sealed record IndexTests
{
    [Fact]
    public void InitializeIsUnique()
    {
        IIndex index = new _Index(new True(), []);
        Assert.True(new MaterializedBool(index.IsUnique).Value);
    }

    [Fact]
    public void InitializeColumns()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new _Column(new RandomString(new UShort(10)), new DateColumnType()),
            new _Column(new RandomString(new UShort(10)), new StringColumnType()),
            new _Column(new RandomString(new UShort(10)), new IntColumnType()),
            new _Column(new RandomString(new UShort(10)), new LongColumnType()),
        ];

        IIndex index = new _Index(new True(), columns);

        Assert.Equal(index.Columns, columns, new ColumnEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Index(new False(), []).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Index(new True(), []).ToString()
        );
    }
}
