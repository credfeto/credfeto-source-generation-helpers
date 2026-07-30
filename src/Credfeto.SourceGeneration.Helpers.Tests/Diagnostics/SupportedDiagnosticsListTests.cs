using System.Collections.Immutable;
using Credfeto.SourceGeneration.Helpers.Diagnostics;
using FunFair.Test.Common;
using Microsoft.CodeAnalysis;
using Xunit;

namespace Credfeto.SourceGeneration.Helpers.Tests.Diagnostics;

public sealed class SupportedDiagnosticsListTests : TestBase
{
    [Fact]
    public void BuildReturnsSingleElementArray()
    {
        DiagnosticDescriptor rule = RuleHelpers.CreateRule(
            code: "TST001",
            category: "Test",
            title: "Title",
            message: "Message"
        );

        ImmutableArray<DiagnosticDescriptor> result = SupportedDiagnosticsList.Build(rule);

        Assert.Single(result);
    }

    [Fact]
    public void BuildReturnsArrayContainingSuppliedRule()
    {
        DiagnosticDescriptor rule = RuleHelpers.CreateRule(
            code: "TST001",
            category: "Test",
            title: "Title",
            message: "Message"
        );

        ImmutableArray<DiagnosticDescriptor> result = SupportedDiagnosticsList.Build(rule);

        Assert.Same(expected: rule, actual: result[0]);
    }
}
