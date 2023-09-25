using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace FastLogr.Generator;

public record LogMessageToGenerate(string ClassName,
    SyntaxNodeOrTokenList ActionTypes,
    LogLevel LogLevel,
    EventId EventId,
    string TemplateMessage,
    IEnumerable<UsingDirectiveSyntax> Usings, BaseNamespaceDeclarationSyntax Namespace)
{
    public readonly BaseNamespaceDeclarationSyntax Namespace = Namespace;
    public readonly string ClassName = ClassName;
    public readonly SyntaxNodeOrTokenList ActionTypes = ActionTypes;
    public readonly LogLevel LogLevel = LogLevel;
    public readonly EventId EventId = EventId;
    public readonly string TemplateMessage = TemplateMessage;
    public readonly IEnumerable<UsingDirectiveSyntax> Usings = Usings;
}