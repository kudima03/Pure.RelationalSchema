# Changelog

All notable changes to Pure.RelationalSchema are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [2.0.3] — 2026-06-25

- Maintenance release: dependency and build updates.

## [2.0.2] — 2026-05-20

- Maintenance release: dependency and build updates.

## [2.0.1] — 2026-05-07

- Maintenance release: dependency and build updates.

## [2.0.0] — 2026-03-11

### Removed

- **Breaking:** `RowDeterminedHashColumn` removed from the `Column` namespace.

## [1.4.0] — 2026-03-02

### Added

- **`DoubleColumnType`** — `IColumnType` implementation with `Name` `"double"`.
- **`FloatColumnType`** — `IColumnType` implementation with `Name` `"float"`.
- **`UuidColumnType`** — `IColumnType` implementation with `Name` `"uuid"`.

## [1.3.0] — 2025-12-02

### Changed

- Package now multi-targets `net7.0`, `net8.0`, `net9.0`, and `net10.0` (previously `net9.0` only).

## [1.2.0] — 2025-11-04

- Maintenance release: dependency and build updates.

## [1.1.0] — 2025-09-28

### Added

- **`RowDeterminedHashColumn`** — `IColumn` implementation with `Name` `"determined_hash_column"` and `Type` `DeterminedHashColumnType`.

## [1.0.0] — 2025-09-26

### Added

- **`DeterminedHashColumnType`** — `IColumnType` implementation with `Name` `"determined_hash"`.

### Changed

- **Breaking:** `ForeignKey.ReferencingColumn` and `ForeignKey.ReferencedColumn` (single `IColumn`) replaced by
  `ReferencingColumns` and `ReferencedColumns` (`IEnumerable<IColumn>`), allowing composite foreign keys over
  multiple columns.

## [0.3.0] — 2025-09-22

### Added

- **`BoolColumnType`** — `IColumnType` implementation with `Name` `"bool"`.

## [0.2.0] — 2025-08-21

### Added

- `IColumnType.Name` is now a public property (`DateColumnType`, `DateTimeColumnType`, `IntColumnType`,
  `LongColumnType`, `StringColumnType`, `TimeColumnType`, `UIntColumnType`, `ULongColumnType`,
  `UShortColumnType`), previously accessible only through an explicit interface implementation.

## [0.1.0] — 2025-06-24

### Added

Initial release of `Pure.RelationalSchema` — sealed record implementations of the relational schema
domain model from `Pure.RelationalSchema.Abstractions`:

- **`Schema`** — a named schema containing tables and cross-table foreign keys (`ISchema`).
- **`Table`** — a named table with columns and indexes (`ITable`).
- **`Column`** — a named column with an associated column type (`IColumn`).
- **`Index`** — a unique or non-unique index over one or more columns (`IIndex`).
- **`ForeignKey`** — a referential constraint between columns in two tables (`IForeignKey`).
- Column types (`IColumnType`): `StringColumnType`, `IntColumnType`, `LongColumnType`, `UIntColumnType`,
  `ULongColumnType`, `UShortColumnType`, `DateColumnType`, `TimeColumnType`, `DateTimeColumnType`.
