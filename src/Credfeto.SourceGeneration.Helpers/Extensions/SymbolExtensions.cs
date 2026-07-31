using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Credfeto.SourceGeneration.Helpers.Extensions;

public static class SymbolExtensions
{
    private static readonly Type ObsoleteType = typeof(ObsoleteAttribute);
    private static readonly Type DescriptionType = typeof(DescriptionAttribute);

    public static bool HasObsoleteAttribute(this ISymbol symbol)
    {
        return symbol.GetAttributes().Any(IsObsoleteAttribute);
    }

    public static bool IsObsoleteAttribute(this AttributeData attributeData)
    {
        return attributeData.AttributeClass is not null
            && MatchesType(type: ObsoleteType, symbol: attributeData.AttributeClass);
    }

    public static bool IsDescriptionAttribute(this AttributeData attributeData)
    {
        return attributeData.AttributeClass is not null
            && MatchesType(type: DescriptionType, symbol: attributeData.AttributeClass);
    }

    private static bool MatchesType(Type type, INamedTypeSymbol symbol)
    {
        return StringComparer.Ordinal.Equals(x: symbol.Name, y: type.Name)
            && StringComparer.Ordinal.Equals(symbol.ContainingNamespace.ToDisplayString(), y: type.Namespace);
    }
}
