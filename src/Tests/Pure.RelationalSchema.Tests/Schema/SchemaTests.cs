using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Materialized.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Random;
using Pure.RelationalSchema.Tests.EqualityComparers;
using _Schema = Pure.RelationalSchema.Schema.Schema;

namespace Pure.RelationalSchema.Tests.Schema;

public sealed record SchemaTests
{
    [Fact]
    public void InitializeName()
    {
        IString expectedName = new RandomString(new UShort(10));
        ISchema schema = new _Schema(expectedName, [], []);
        Assert.Equal(
            new MaterializedString(expectedName).Value,
            new MaterializedString(schema.Name).Value
        );
    }

    [Fact]
    public void InitializeForeignKeys()
    {
        IEnumerable<IForeignKey> foreignKeys = new RandomForeignKeysCollection();

        ISchema schema = new _Schema(new RandomString(), new RandomTablesCollection(), foreignKeys);

        Assert.Equal(foreignKeys, schema.ForeignKeys, new ForeignKeyEqualityComparer());
    }

    [Fact]
    public void InitializeTables()
    {
        IEnumerable<ITable> tables = new RandomTablesCollection();

        ISchema schema = new _Schema(new RandomString(), tables, new RandomForeignKeysCollection());

        Assert.Equal(tables, schema.Tables, new TableEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Schema(new RandomString(), new RandomTablesCollection(), new RandomForeignKeysCollection()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Schema(new RandomString(), new RandomTablesCollection(), new RandomForeignKeysCollection()).ToString()
        );
    }
}
