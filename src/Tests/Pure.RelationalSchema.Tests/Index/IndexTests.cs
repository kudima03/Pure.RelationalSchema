using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Bool;
using Pure.Primitives.Materialized.Bool;
using Pure.Primitives.Random.Bool;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Random;
using Pure.RelationalSchema.Tests.EqualityComparers;
using _Index = Pure.RelationalSchema.Index.Index;

namespace Pure.RelationalSchema.Tests.Index;

public sealed record IndexTests
{
    [Fact]
    public void InitializeIsUnique()
    {
        IBool uniqueness = new RandomBool();
        IIndex index = new _Index(uniqueness, []);
        Assert.Equal(new MaterializedBool(uniqueness).Value, new MaterializedBool(index.IsUnique).Value);
    }

    [Fact]
    public void InitializeColumns()
    {
        IEnumerable<IColumn> columns = new RandomColumnsCollection();

        IIndex index = new _Index(new True(), columns);

        Assert.Equal(index.Columns, columns, new ColumnEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Index(new RandomBool(), new RandomColumnsCollection()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Index(new RandomBool(), new RandomColumnsCollection()).ToString()
        );
    }
}
