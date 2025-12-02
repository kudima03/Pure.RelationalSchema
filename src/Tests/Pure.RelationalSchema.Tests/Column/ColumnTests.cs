using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.Random;
using Pure.RelationalSchema.Tests.EqualityComparers;
using _Column = Pure.RelationalSchema.Column.Column;

namespace Pure.RelationalSchema.Tests.Column;

public sealed record ColumnTests
{
    [Fact]
    public void InitializeType()
    {
        IColumnType expectedType = new RandomColumnType();
        IColumn column = new _Column(new RandomString(), expectedType);
        Assert.Equal(expectedType, column.Type, new ColumnTypeEqualityComparer());
    }

    [Fact]
    public void InitializeName()
    {
        IString expectedTypeName = new RandomString(new UShort(10));
        IColumn column = new _Column(expectedTypeName, new RandomColumnType());
        Assert.Equal(expectedTypeName.TextValue, column.Name.TextValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Column(new RandomString(), new RandomColumnType()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Column(new RandomString(), new RandomColumnType()).ToString()
        );
    }
}
