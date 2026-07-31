using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Credfeto.SourceGeneration.Helpers.Tests;

internal static class CompilationHelpers
{
    private static readonly Lazy<IReadOnlyList<MetadataReference>> BaseReferences = new(BuildBaseReferences);

    public static CSharpCompilation CreateCompilation(
        string source,
        IEnumerable<MetadataReference>? additionalReferences = null
    )
    {
        List<MetadataReference> references = [.. BaseReferences.Value];

        if (additionalReferences is not null)
        {
            references.AddRange(additionalReferences);
        }

        return CSharpCompilation.Create(
            assemblyName: "TestAssembly",
            syntaxTrees: [CSharpSyntaxTree.ParseText(source, cancellationToken: TestContext.Current.CancellationToken)],
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );
    }

    private static IReadOnlyList<MetadataReference> BuildBaseReferences()
    {
        HashSet<string> addedPaths = new(StringComparer.OrdinalIgnoreCase);
        List<MetadataReference> references = [];

        AddReference(references, addedPaths, typeof(object));
        AddReference(references, addedPaths, typeof(Attribute));
        AddReference(references, addedPaths, typeof(System.ComponentModel.DescriptionAttribute));
        AddReference(references, addedPaths, typeof(System.Diagnostics.UnreachableException));
        AddReference(references, addedPaths, typeof(System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute));

        // Add System.Runtime which provides core types
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            string? name = assembly.GetName().Name;

            if (
                StringComparer.Ordinal.Equals(name, "System.Runtime")
                || StringComparer.Ordinal.Equals(name, "netstandard")
            )
            {
                TryAddReference(references, addedPaths, assembly.Location);
            }
        }

        return references;
    }

    private static void AddReference(List<MetadataReference> references, HashSet<string> addedPaths, Type type)
    {
        TryAddReference(references, addedPaths, type.Assembly.Location);
    }

    private static void TryAddReference(List<MetadataReference> references, HashSet<string> addedPaths, string path)
    {
        if (!string.IsNullOrEmpty(path) && addedPaths.Add(path))
        {
            references.Add(MetadataReference.CreateFromFile(path));
        }
    }
}
