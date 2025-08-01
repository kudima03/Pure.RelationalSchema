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
using _Column = Pure.RelationalSchema.Column.Column;
using _ForeignKey = Pure.RelationalSchema.ForeignKey.ForeignKey;
using _Index = Pure.RelationalSchema.Index.Index;
using _Schema = Pure.RelationalSchema.Schema.Schema;
using _Table = Pure.RelationalSchema.Table.Table;

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
        IReadOnlyCollection<IColumn> columns =
        [
            new _Column(new RandomString(new UShort(10)), new DateColumnType()),
            new _Column(new RandomString(new UShort(10)), new StringColumnType()),
            new _Column(new RandomString(new UShort(10)), new IntColumnType()),
            new _Column(new RandomString(new UShort(10)), new LongColumnType()),
            new _Column(new RandomString(new UShort(10)), new ULongColumnType()),
            new _Column(new RandomString(new UShort(10)), new UShortColumnType()),
            new _Column(new RandomString(new UShort(10)), new UIntColumnType()),
            new _Column(new RandomString(new UShort(10)), new ULongColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new _Index(new True(), columns.Take(2)),
            new _Index(new False(), columns.Skip(2).Take(2)),
            new _Index(new False(), columns.Skip(4).Take(2)),
            new _Index(new False(), columns.Skip(6).Take(2)),
        ];

        IReadOnlyCollection<ITable> tables =
        [
            new _Table(new RandomString(new UShort(10)), columns, indexes.Take(1)),
            new _Table(new RandomString(new UShort(10)), columns, indexes.Skip(1).Take(1)),
            new _Table(new RandomString(new UShort(10)), columns, indexes.Skip(2).Take(1)),
            new _Table(new RandomString(new UShort(10)), columns, indexes.Skip(3).Take(1)),
        ];

        IReadOnlyCollection<IForeignKey> foreignKeys =
        [
            new _ForeignKey(
                tables.First(),
                columns.First(),
                tables.Skip(1).First(),
                columns.Skip(1).First()
            ),
            new _ForeignKey(
                tables.Skip(1).First(),
                columns.Skip(1).First(),
                tables.Skip(2).First(),
                columns.Skip(2).First()
            ),
        ];

        ISchema schema = new _Schema(new EmptyString(), tables, foreignKeys);

        Assert.Equal(foreignKeys, schema.ForeignKeys, new ForeignKeyEqualityComparer());
    }

    [Fact]
    public void InitializeTables()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new _Column(new RandomString(new UShort(10)), new DateColumnType()),
            new _Column(new RandomString(new UShort(10)), new StringColumnType()),
            new _Column(new RandomString(new UShort(10)), new IntColumnType()),
            new _Column(new RandomString(new UShort(10)), new LongColumnType()),
            new _Column(new RandomString(new UShort(10)), new ULongColumnType()),
            new _Column(new RandomString(new UShort(10)), new UShortColumnType()),
            new _Column(new RandomString(new UShort(10)), new UIntColumnType()),
            new _Column(new RandomString(new UShort(10)), new ULongColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new _Index(new True(), columns.Take(2)),
            new _Index(new False(), columns.Skip(2).Take(2)),
            new _Index(new False(), columns.Skip(4).Take(2)),
            new _Index(new False(), columns.Skip(6).Take(2)),
        ];

        IReadOnlyCollection<ITable> tables =
        [
            new _Table(new RandomString(new UShort(10)), columns, indexes.Take(1)),
            new _Table(new RandomString(new UShort(10)), columns, indexes.Skip(1).Take(1)),
            new _Table(new RandomString(new UShort(10)), columns, indexes.Skip(2).Take(1)),
            new _Table(new RandomString(new UShort(10)), columns, indexes.Skip(3).Take(1)),
        ];

        ISchema schema = new _Schema(new EmptyString(), tables, []);

        Assert.Equal(tables, schema.Tables, new TableEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Schema(new EmptyString(), [], []).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _Schema(new EmptyString(), [], []).ToString()
        );
    }
}
