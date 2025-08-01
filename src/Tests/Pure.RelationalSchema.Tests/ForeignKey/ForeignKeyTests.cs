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
using _Column = Pure.RelationalSchema.Column.Column;
using _ForeignKey = Pure.RelationalSchema.ForeignKey.ForeignKey;
using _Index = Pure.RelationalSchema.Index.Index;
using _Table = Pure.RelationalSchema.Table.Table;

namespace Pure.RelationalSchema.Tests.ForeignKey;

public sealed record ForeignKeyTests
{
    [Fact]
    public void InitializeName()
    {
        IString expectedName = new RandomString(new UShort(10));
        ITable table = new _Table(expectedName, [], []);
        Assert.Equal(
            new MaterializedString(expectedName).Value,
            new MaterializedString(table.Name).Value
        );
    }

    [Fact]
    public void InitializeReferencedColumn()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new _Column(new RandomString(new UShort(10)), new LongColumnType()),
            new _Column(new RandomString(new UShort(10)), new DateColumnType()),
            new _Column(new RandomString(new UShort(10)), new IntColumnType()),
            new _Column(new RandomString(new UShort(10)), new StringColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new _Index(new True(), columns.Take(2)),
            new _Index(new False(), columns.Skip(2)),
        ];

        ITable referencingTable = new _Table(
            new RandomString(new UShort(10)),
            columns.Take(2),
            indexes
        );
        ITable referencedTable = new _Table(
            new RandomString(new UShort(10)),
            columns,
            indexes
        );

        IForeignKey foreignKey = new _ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.Last()
        );

        Assert.Equal(
            referencedTable.Columns.Last(),
            foreignKey.ReferencedColumn,
            new ColumnEqualityComparer()
        );
    }

    [Fact]
    public void InitializeReferencingColumn()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new _Column(new RandomString(new UShort(10)), new LongColumnType()),
            new _Column(new RandomString(new UShort(10)), new DateColumnType()),
            new _Column(new RandomString(new UShort(10)), new IntColumnType()),
            new _Column(new RandomString(new UShort(10)), new StringColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new _Index(new True(), columns.Take(2)),
            new _Index(new False(), columns.Skip(2)),
        ];

        ITable referencingTable = new _Table(
            new RandomString(new UShort(10)),
            columns.Take(2),
            indexes
        );
        ITable referencedTable = new _Table(
            new RandomString(new UShort(10)),
            columns,
            indexes
        );

        IForeignKey foreignKey = new _ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.Last()
        );

        Assert.Equal(
            referencingTable.Columns.First(),
            foreignKey.ReferencingColumn,
            new ColumnEqualityComparer()
        );
    }

    [Fact]
    public void InitializeReferencedTable()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new _Column(new RandomString(new UShort(10)), new LongColumnType()),
            new _Column(new RandomString(new UShort(10)), new DateColumnType()),
            new _Column(new RandomString(new UShort(10)), new IntColumnType()),
            new _Column(new RandomString(new UShort(10)), new StringColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new _Index(new True(), columns.Take(2)),
            new _Index(new False(), columns.Skip(2)),
        ];

        ITable referencingTable = new _Table(
            new RandomString(new UShort(10)),
            columns.Take(2),
            indexes
        );

        ITable referencedTable = new _Table(
            new RandomString(new UShort(10)),
            columns,
            indexes
        );

        IForeignKey foreignKey = new _ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.Last()
        );

        Assert.Equal(
            referencedTable,
            foreignKey.ReferencedTable,
            new TableEqualityComparer()
        );
    }

    [Fact]
    public void InitializeReferencingTable()
    {
        IReadOnlyCollection<IColumn> columns =
        [
            new _Column(new RandomString(new UShort(10)), new LongColumnType()),
            new _Column(new RandomString(new UShort(10)), new DateColumnType()),
            new _Column(new RandomString(new UShort(10)), new IntColumnType()),
            new _Column(new RandomString(new UShort(10)), new StringColumnType()),
        ];

        IReadOnlyCollection<IIndex> indexes =
        [
            new _Index(new True(), columns.Take(2)),
            new _Index(new False(), columns.Skip(2)),
        ];

        ITable referencingTable = new _Table(
            new RandomString(new UShort(10)),
            columns.Take(2),
            indexes
        );

        ITable referencedTable = new _Table(
            new RandomString(new UShort(10)),
            columns,
            indexes
        );

        IForeignKey foreignKey = new _ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.Last()
        );

        Assert.Equal(
            referencingTable,
            foreignKey.ReferencingTable,
            new TableEqualityComparer()
        );
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _ForeignKey(
                new _Table(new EmptyString(), [], []),
                new _Column(new EmptyString(), new DateColumnType()),
                new _Table(new EmptyString(), [], []),
                new _Column(new EmptyString(), new TimeColumnType())
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _ForeignKey(
                new _Table(new EmptyString(), [], []),
                new _Column(new EmptyString(), new DateColumnType()),
                new _Table(new EmptyString(), [], []),
                new _Column(new EmptyString(), new TimeColumnType())
            ).ToString()
        );
    }
}
