using Pure.Primitives.Materialized.String;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.ColumnType;

namespace Pure.RelationalSchema.Tests.ColumnType;

public sealed record TimeColumnTypeTests
{
    [Fact]
    public void ContainCorrectTypeName()
    {
        const string expectedTypeName = "time";
        IColumnType columnType = new TimeColumnType();
        Assert.Equal(expectedTypeName, new MaterializedString(columnType.Name).Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new TimeColumnType().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new TimeColumnType().ToString());
    }
}