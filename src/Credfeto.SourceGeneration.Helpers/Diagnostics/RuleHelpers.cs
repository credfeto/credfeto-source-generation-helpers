using Microsoft.CodeAnalysis;

namespace Credfeto.SourceGeneration.Helpers.Diagnostics;

public static class RuleHelpers
{
    public static DiagnosticDescriptor CreateRule(
        string code,
        string category,
        string title,
        string message,
        string? description = null,
        DiagnosticSeverity defaultSeverity = DiagnosticSeverity.Error,
        bool isEnabledByDefault = true
    )
    {
        LiteralString translatableTitle = new(title);
        LiteralString translatableMessage = new(message);
        LiteralString translatableDescription = new(description ?? message);

        return new(
            id: code,
            title: translatableTitle,
            messageFormat: translatableMessage,
            category: category,
            defaultSeverity: defaultSeverity,
            isEnabledByDefault: isEnabledByDefault,
            description: translatableDescription
        );
    }
}
