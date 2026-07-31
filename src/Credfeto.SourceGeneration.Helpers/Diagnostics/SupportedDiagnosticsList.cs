using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace Credfeto.SourceGeneration.Helpers.Diagnostics;

public static class SupportedDiagnosticsList
{
    public static ImmutableArray<DiagnosticDescriptor> Build(DiagnosticDescriptor rule)
    {
        return [rule];
    }
}
