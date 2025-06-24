using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Bool;
using Pure.Primitives.Materialized.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using Pure.Primitives.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.Tests.EqualityComparers;

namespace Pure.RelationalSchema.Tests.ForeignKey;

using Column = RelationalSchema.Column.Column;
using ForeignKey = RelationalSchema.ForeignKey.ForeignKey;
using Index = RelationalSchema.Index.Index;
using Table = RelationalSchema.Table.Table;


public sealed record ForeignKeyTests
{
    [Fact]
    public void InitializeName()
    {
        IString expectedName = new RandomString(new UShort(10));
        ITable table = new Table(expectedName, [], []);
        Assert.Equal(new MaterializedString(expectedName).Value, new MaterializedString(table.Name).Value);
    }

    [Fact]
    public void InitializeReferencedColumn()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new Column(new RandomString(new UShort(10)), new LongColumnType()),
            new Column(new RandomString(new UShort(10)), new DateColumnType()),
            new Column(new RandomString(new UShort(10)), new IntColumnType()),
            new Column(new RandomString(new UShort(10)), new StringColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new Index(new True(), columns.Take(2)),
            new Index(new False(), columns.Skip(2)),
        ];

        ITable referencingTable = new Table(new RandomString(new UShort(10)), columns.Take(2), indexes);
        ITable referencedTable = new Table(new RandomString(new UShort(10)), columns, indexes);

        IForeignKey foreignKey = new ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.Last());

        Assert.Equal(referencedTable.Columns.Last(), foreignKey.ReferencedColumn, new ColumnEqualityComparer());
    }

    [Fact]
    public void InitializeReferencingColumn()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new Column(new RandomString(new UShort(10)), new LongColumnType()),
            new Column(new RandomString(new UShort(10)), new DateColumnType()),
            new Column(new RandomString(new UShort(10)), new IntColumnType()),
            new Column(new RandomString(new UShort(10)), new StringColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new Index(new True(), columns.Take(2)),
            new Index(new False(), columns.Skip(2)),
        ];

        ITable referencingTable = new Table(new RandomString(new UShort(10)), columns.Take(2), indexes);
        ITable referencedTable = new Table(new RandomString(new UShort(10)), columns, indexes);

        IForeignKey foreignKey = new ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.Last());

        Assert.Equal(referencingTable.Columns.First(), foreignKey.ReferencingColumn, new ColumnEqualityComparer());
    }

    [Fact]
    public void InitializeReferencedTable()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new Column(new RandomString(new UShort(10)), new LongColumnType()),
            new Column(new RandomString(new UShort(10)), new DateColumnType()),
            new Column(new RandomString(new UShort(10)), new IntColumnType()),
            new Column(new RandomString(new UShort(10)), new StringColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new Index(new True(), columns.Take(2)),
            new Index(new False(), columns.Skip(2)),
        ];

        ITable referencingTable = new Table(new RandomString(new UShort(10)), columns.Take(2), indexes);
        ITable referencedTable = new Table(new RandomString(new UShort(10)), columns, indexes);

        IForeignKey foreignKey = new ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.Last());

        Assert.Equal(referencedTable, foreignKey.ReferencedTable, new TableEqualityComparer());
    }

    [Fact]
    public void InitializeReferencingTable()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new Column(new RandomString(new UShort(10)), new LongColumnType()),
            new Column(new RandomString(new UShort(10)), new DateColumnType()),
            new Column(new RandomString(new UShort(10)), new IntColumnType()),
            new Column(new RandomString(new UShort(10)), new StringColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new Index(new True(), columns.Take(2)),
            new Index(new False(), columns.Skip(2)),
        ];

        ITable referencingTable = new Table(new RandomString(new UShort(10)), columns.Take(2), indexes);
        ITable referencedTable = new Table(new RandomString(new UShort(10)), columns, indexes);

        IForeignKey foreignKey = new ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.Last());

        Assert.Equal(referencingTable, foreignKey.ReferencingTable, new TableEqualityComparer());
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new ForeignKey(
            new Table(new EmptyString(), [], []),
            new Column(new EmptyString(), new DateColumnType()),
            new Table(new EmptyString(), [], []),
            new Column(new EmptyString(), new TimeColumnType())).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new ForeignKey(
            new Table(new EmptyString(), [], []),
            new Column(new EmptyString(), new DateColumnType()),
            new Table(new EmptyString(), [], []),
            new Column(new EmptyString(), new TimeColumnType())).ToString());
    }
}