using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Materialized.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.Primitives.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.Tests.EqualityComparers;

namespace Pure.RelationalSchema.Tests.Column;

using Column = RelationalSchema.Column.Column;

public sealed record ColumnTests
{
    [Fact]
    public void InitializeType()
    {
        IColumnType expectedType = new TimeColumnType();
        IColumn column = new Column(new EmptyString(), expectedType);
        Assert.Equal(expectedType, column.Type, new ColumnTypeEqualityComparer());
    }

    [Fact]
    public void InitializeName()
    {
        IString expectedTypeName = new RandomString(new UShort(10));
        IColumn column = new Column(expectedTypeName, new TimeColumnType());
        Assert.Equal(new MaterializedString(expectedTypeName).Value, new MaterializedString(column.Name).Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Column(new EmptyString(), new DateColumnType()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Column(new EmptyString(), new TimeColumnType()).ToString());
    }
}