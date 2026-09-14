# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

<!--
Please ADD ALL Changes to the UNRELEASED SECTION and not a specific release
-->

## [Unreleased]
### Security
### Added
### Fixed
- Test project - Corrected xunit v3 test host package reference (xunit.v3.aot.mtp-v2) and IncludeAssets metadata so the build check passes
### Changed
- SDK - Updated DotNet SDK to 10.0.401
- Dependencies - Updated CSharpIsNullAnalyzer to 0.2.19
- Dependencies - Updated Meziantou.Analyzer to 3.0.253
- Dependencies - Updated Microsoft.CodeAnalysis.Analyzers to 5.9.0
- Dependencies - Updated Nullable.Extended.Analyzer to 1.16.6891
- Dependencies - Updated Roslynator.Analyzers to 5.0.0
- Dependencies - Updated SonarAnalyzer.CSharp to 10.34.0.3385
- Dependencies - Updated xunit.v3 to 4.0.0
- Dependencies - Updated FunFair.Test.Source.Generator to 6.4.6.2749
- Dependencies - Updated FunFair.Test to 6.4.6.2749
- Dependencies - Updated xunit.analyzers to 2.1.0
### Deprecated
### Removed
### Deployment Changes

<!--
Releases that have at least been deployed to staging, BUT NOT necessarily released to live.  Changes should be moved from [Unreleased] into here as they are merged into the appropriate release branch
-->

## [0.0.4] - 2026-08-20
### Changed
- SDK - Updated DotNet SDK to 10.0.400

## [0.0.3] - 2026-07-31
### Added
- Add Credfeto.SourceGeneration.Helpers library: shared Roslyn source-generator building blocks (code emission, diagnostic rule helpers, generic Roslyn extensions) for reuse across Credfeto source generators.

## [0.0.2] - 2026-07-16
### Changed
- SDK - Updated DotNet SDK to 10.0.302

## [0.0.1] - 2026-06-11
### Changed
- die() must output to stderr so error messages are not swallowed by stdout pipelines
- SDK - Updated DotNet SDK to 10.0.301

## [0.0.0] - Project created