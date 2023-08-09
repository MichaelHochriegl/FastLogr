using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace FastLogr.Generator;

public class LogMessageToGenerate
{
    public readonly BaseNamespaceDeclarationSyntax Namespace;
    public readonly string ClassName;
    public readonly SyntaxNodeOrTokenList ActionTypes;
    public readonly LogLevel LogLevel;
    public readonly EventId EventId;
    public readonly string TemplateMessage;
    public readonly IEnumerable<UsingDirectiveSyntax> Usings;
    
    public LogMessageToGenerate(string className,
        SyntaxNodeOrTokenList actionTypes,
        LogLevel logLevel,
        EventId eventId,
        string templateMessage,
        IEnumerable<UsingDirectiveSyntax> usings, BaseNamespaceDeclarationSyntax ns)
    {
        ClassName = className;
        ActionTypes = actionTypes;
        LogLevel = logLevel;
        EventId = eventId;
        TemplateMessage = templateMessage;
        Usings = usings;
        Namespace = ns;
    }
}