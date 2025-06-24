using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Bool;
using Pure.Primitives.Materialized.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.Primitives.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Schema;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.Tests.EqualityComparers;

namespace Pure.RelationalSchema.Tests.Schema;

using Column = RelationalSchema.Column.Column;
using ForeignKey = RelationalSchema.ForeignKey.ForeignKey;
using Index = RelationalSchema.Index.Index;
using Schema = RelationalSchema.Schema.Schema;
using Table = RelationalSchema.Table.Table;

public sealed record SchemaTests
{
    [Fact]
    public void InitializeName()
    {
        IString expectedName = new RandomString(new UShort(10));
        ISchema schema = new Schema(expectedName, [], []);
        Assert.Equal(new MaterializedString(expectedName).Value, new MaterializedString(schema.Name).Value);
    }

    [Fact]
    public void InitializeForeignKeys()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new Column(new RandomString(new UShort(10)), new DateColumnType()),
            new Column(new RandomString(new UShort(10)), new StringColumnType()),
            new Column(new RandomString(new UShort(10)), new IntColumnType()),
            new Column(new RandomString(new UShort(10)), new LongColumnType()),
            new Column(new RandomString(new UShort(10)), new ULongColumnType()),
            new Column(new RandomString(new UShort(10)), new UShortColumnType()),
            new Column(new RandomString(new UShort(10)), new UIntColumnType()),
            new Column(new RandomString(new UShort(10)), new ULongColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new Index(new True(), columns.Take(2)),
            new Index(new False(), columns.Skip(2).Take(2)),
            new Index(new False(), columns.Skip(4).Take(2)),
            new Index(new False(), columns.Skip(6).Take(2)),
        ];

        IReadOnlyCollection<ITable> tables =
        [
            new Table(new RandomString(new UShort(10)), columns, indexes.Take(1)),
            new Table(new RandomString(new UShort(10)), columns, indexes.Skip(1).Take(1)),
            new Table(new RandomString(new UShort(10)), columns, indexes.Skip(2).Take(1)),
            new Table(new RandomString(new UShort(10)), columns, indexes.Skip(3).Take(1)),
        ];

        IReadOnlyCollection<IForeignKey> foreignKeys =
        [
            new ForeignKey(tables.First(), columns.First(), tables.Skip(1).First(), columns.Skip(1).First()),
            new ForeignKey(tables.Skip(1).First(), columns.Skip(1).First(), tables.Skip(2).First(), columns.Skip(2).First())
        ];

        ISchema schema = new Schema(new EmptyString(), tables, foreignKeys);

        Assert.Equal(foreignKeys, schema.ForeignKeys, new ForeignKeyEqualityComparer());
    }

    [Fact]
    public void InitializeTables()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new Column(new RandomString(new UShort(10)), new DateColumnType()),
            new Column(new RandomString(new UShort(10)), new StringColumnType()),
            new Column(new RandomString(new UShort(10)), new IntColumnType()),
            new Column(new RandomString(new UShort(10)), new LongColumnType()),
            new Column(new RandomString(new UShort(10)), new ULongColumnType()),
            new Column(new RandomString(new UShort(10)), new UShortColumnType()),
            new Column(new RandomString(new UShort(10)), new UIntColumnType()),
            new Column(new RandomString(new UShort(10)), new ULongColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new Index(new True(), columns.Take(2)),
            new Index(new False(), columns.Skip(2).Take(2)),
            new Index(new False(), columns.Skip(4).Take(2)),
            new Index(new False(), columns.Skip(6).Take(2)),
        ];

        IReadOnlyCollection<ITable> tables =
        [
            new Table(new RandomString(new UShort(10)), columns, indexes.Take(1)),
            new Table(new RandomString(new UShort(10)), columns, indexes.Skip(1).Take(1)),
            new Table(new RandomString(new UShort(10)), columns, indexes.Skip(2).Take(1)),
            new Table(new RandomString(new UShort(10)), columns, indexes.Skip(3).Take(1)),
        ];

        ISchema schema = new Schema(new EmptyString(), tables, []);

        Assert.Equal(tables, schema.Tables, new TableEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Schema(new EmptyString(), [], []).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Schema(new EmptyString(), [], []).ToString());
    }
}