using Pure.Primitives.Number;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.Random;
using Pure.RelationalSchema.Tests.EqualityComparers;
using _ForeignKey = Pure.RelationalSchema.ForeignKey.ForeignKey;

namespace Pure.RelationalSchema.Tests.ForeignKey;

public sealed record ForeignKeyTests
{
    [Fact]
    public void InitializeReferencedColumn()
    {
        ITable referencingTable = new RandomTable(
            new RandomColumnsCollection(new UShort(1))
        );

        ITable referencedTable = new RandomTable(
            new RandomColumnsCollection(new UShort(1))
        );

        IForeignKey foreignKey = new _ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.First()
        );

        Assert.Equal(
            referencedTable.Columns.First(),
            foreignKey.ReferencedColumn,
            new ColumnEqualityComparer()
        );
    }

    [Fact]
    public void InitializeReferencingColumn()
    {
        ITable referencingTable = new RandomTable(
            new RandomColumnsCollection(new UShort(1))
        );

        ITable referencedTable = new RandomTable(
            new RandomColumnsCollection(new UShort(1))
        );

        IForeignKey foreignKey = new _ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.First()
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
        ITable referencingTable = new RandomTable(
            new RandomColumnsCollection(new UShort(1))
        );

        ITable referencedTable = new RandomTable(
            new RandomColumnsCollection(new UShort(1))
        );

        IForeignKey foreignKey = new _ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.First()
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
        ITable referencingTable = new RandomTable(
            new RandomColumnsCollection(new UShort(1))
        );

        ITable referencedTable = new RandomTable(
            new RandomColumnsCollection(new UShort(1))
        );

        IForeignKey foreignKey = new _ForeignKey(
            referencingTable,
            referencingTable.Columns.First(),
            referencedTable,
            referencedTable.Columns.First()
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
                new RandomTable(),
                new RandomColumn(),
                new RandomTable(),
                new RandomColumn()
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new _ForeignKey(
                new RandomTable(),
                new RandomColumn(),
                new RandomTable(),
                new RandomColumn()
            ).ToString()
        );
    }
}
