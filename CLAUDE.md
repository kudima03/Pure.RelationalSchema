# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror /p:RunAnalyzers=true
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format                                 # auto-fix code style
dotnet test --no-build --verbosity normal     # run unit tests
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

## Architecture

This is a **concrete implementation NuGet library**. Every public type is a `sealed record` that implements exactly one interface from `Pure.RelationalSchema.Abstractions`.

**Domain model:**
- `Schema` → `ISchema` — name (`IString`), tables (`IEnumerable<ITable>`), foreign keys (`IEnumerable<IForeignKey>`)
- `Table` → `ITable` — name (`IString`), columns (`IEnumerable<IColumn>`), indexes (`IEnumerable<IIndex>`)
- `Column` → `IColumn` — name (`IString`), type (`IColumnType`)
- `Index` → `IIndex` — isUnique (`IBool`), columns (`IEnumerable<IColumn>`)
- `ForeignKey` → `IForeignKey` — referencingTable, referencingColumns, referencedTable, referencedColumns

**Column types** (`ColumnType/` directory): 14 sealed records all implementing `IColumnType`, each with a hardcoded `Name` (`IString`) value and no other state.

**Primitive types** (`IString`, `IBool`) come from `Pure.Primitives` — never use raw `string` or `bool` in domain model properties.

All records override `GetHashCode()` and `ToString()` to throw `NotSupportedException` — this is intentional.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All types must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 2.0.3`. Breaking API changes fail the build.

**Publishing:** triggered by pushing a semver tag (e.g. `2.1.0`). The tag value becomes the `PackageVersion`.

**Tests** live under `src/Tests/Pure.RelationalSchema.Tests/` and use xunit with ≥98% coverage enforced in CI.

## Code Style

Enforced via `.editorconfig` and `dotnet format --verify-no-changes` in CI:

- No `var` — always use explicit types
- No expression-bodied methods or constructors — use block bodies
- Expression-bodied properties and accessors are required
- File-scoped namespaces (`namespace Foo;` not `namespace Foo { }`)
- `using` directives outside the namespace
- Explicit `new` — never `new()` when the type is not apparent
- Max line length: 90 characters
- All braces on their own line (`csharp_new_line_before_open_brace = all`)
- Private fields: `_camelCase`; no non-private instance fields allowed

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
