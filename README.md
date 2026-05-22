# Pure.RelationalSchema

Concrete implementations of the relational schema domain model for the **Pure** ecosystem — schemas, tables, columns, indexes, and foreign keys.

[![.NET build & test](https://github.com/kudima03/Pure.RelationalSchema/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.RelationalSchema/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema)](https://www.nuget.org/packages/Pure.RelationalSchema)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema` provides sealed record implementations of the abstract relational schema interfaces defined in `Pure.RelationalSchema.Abstractions`. All types use `IString` and `IBool` from `Pure.Primitives` instead of raw CLR primitives, keeping the domain model consistent with the broader Pure ecosystem.

## Domain Model

| Type | Implements | Description |
|---|---|---|
| `Schema` | `ISchema` | A named schema containing tables and cross-table foreign keys |
| `Table` | `ITable` | A named table with columns and indexes |
| `Column` | `IColumn` | A named column with an associated column type |
| `Index` | `IIndex` | An index (unique or non-unique) over one or more columns |
| `ForeignKey` | `IForeignKey` | A referential constraint between columns in two tables |

## Column Types

All column types implement `IColumnType` and expose a string `Name` property.

| Type | Name value |
|---|---|
| `StringColumnType` | `"string"` |
| `IntColumnType` | `"int"` |
| `LongColumnType` | `"long"` |
| `UIntColumnType` | `"uint"` |
| `ULongColumnType` | `"ulong"` |
| `UShortColumnType` | `"ushort"` |
| `FloatColumnType` | `"float"` |
| `DoubleColumnType` | `"double"` |
| `BoolColumnType` | `"bool"` |
| `UuidColumnType` | `"uuid"` |
| `DateColumnType` | `"date"` |
| `TimeColumnType` | `"time"` |
| `DateTimeColumnType` | `"datetime"` |
| `DeterminedHashColumnType` | `"determined_hash"` |

## Dependencies

- [`Pure.RelationalSchema.Abstractions` 1.2.0](https://github.com/kudima03/Pure.RelationalSchema.Abstractions/tree/1.2.0) — abstract interfaces for the relational schema domain model (`ISchema`, `ITable`, `IColumn`, `IColumnType`, `IIndex`, `IForeignKey`)
- [`Pure.Primitives` 3.6.4](https://github.com/kudima03/Pure.Primitives/tree/3.6.4) — concrete implementations of Pure primitive types (`IString`, `IBool`, etc.)

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```bash
dotnet add package Pure.RelationalSchema
```

## Usage

```csharp
using Pure.Primitives.String;
using Pure.Primitives.Bool;
using Pure.RelationalSchema.Schema;
using Pure.RelationalSchema.Table;
using Pure.RelationalSchema.Column;
using Pure.RelationalSchema.ColumnType;
using Pure.RelationalSchema.Index;
using Pure.RelationalSchema.ForeignKey;

IColumn id = new Column(new String("id"), new UuidColumnType());
IColumn name = new Column(new String("name"), new StringColumnType());
IIndex primaryKey = new Index(new Bool(true), [id]);

ITable usersTable = new Table(new String("users"), [id, name], [primaryKey]);

ISchema schema = new Schema(new String("public"), [usersTable], []);
```
