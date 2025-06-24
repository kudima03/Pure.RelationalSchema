using Pure.Primitives.Bool;
using Pure.Primitives.Materialized.Bool;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.Tests.EqualityComparers;

namespace Pure.RelationalSchema.Tests.Index;

using Column = RelationalSchema.Column.Column;
using Index = RelationalSchema.Index.Index;

public sealed record IndexTests
{
    [Fact]
    public void InitializeIsUnique()
    {
        IIndex index = new Index(new True(), []);
        Assert.True(new MaterializedBool(index.IsUnique).Value);
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

        IIndex index = new Index(new True(), columns);

        Assert.Equal(index.Columns, columns, new ColumnEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Index(new False(), []).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Index(new True(), []).ToString());
    }
}