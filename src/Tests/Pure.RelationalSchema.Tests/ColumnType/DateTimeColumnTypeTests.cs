using Pure.Primitives.Materialized.String;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.ColumnType;

namespace Pure.RelationalSchema.Tests.ColumnType;

public sealed record DateTimeColumnTypeTests
{
    [Fact]
    public void ContainCorrectTypeName()
    {
        const string expectedTypeName = "datetime";
        IColumnType columnType = new DateTimeColumnType();
        Assert.Equal(expectedTypeName, new MaterializedString(columnType.Name).Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new DateTimeColumnType().GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new DateTimeColumnType().ToString()
        );
    }
}
