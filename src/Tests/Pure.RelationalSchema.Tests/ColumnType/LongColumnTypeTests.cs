using Pure.Primitives.Materialized.String;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.ColumnType;

namespace Pure.RelationalSchema.Tests.ColumnType;

public sealed record LongColumnTypeTests
{
    [Fact]
    public void ContainCorrectTypeName()
    {
        const string expectedTypeName = "long";
        IColumnType columnType = new LongColumnType();
        Assert.Equal(expectedTypeName, new MaterializedString(columnType.Name).Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new LongColumnType().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new LongColumnType().ToString());
    }
}